using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using LaFabriqueaBriques.Models;
using Microsoft.EntityFrameworkCore;

namespace LaFabriqueaBriques.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // Afficher la page d'inscription
        public IActionResult Register()
        {
            return View();
        }

        // Traitement de l'inscription
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Cet email est déjà utilisé.");
                return View();
            }

            // Hashage du mot de passe (simple, utilisez des bibliothèques comme BCrypt en production)
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Role = 0;
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        // Afficher la page de connexion
        public IActionResult Login()
        {
            return View();
        }

        // Traitement de la connexion
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                ModelState.AddModelError("", "Email ou mot de passe incorrect.");
                return View();
            }

            // Création des claims pour la session utilisateur
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
             new Claim("Role", user.Role.ToString())
        };

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
            HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }

        // Déconnexion
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult ConfirmOrder()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userEmail))
                return Unauthorized();

            var user = _context.Users
                .Include(u => u.Cart)
                .FirstOrDefault(u => u.Email == userEmail);

            if (user == null || !user.Cart.Any())
                return RedirectToAction("Profile", "Account");

            var order = new Order
            {
                UserId = user.Id,
                Legos = new List<Lego>(user.Cart)
            };

            _context.Orders.Add(order);
            user.Cart.Clear();
            _context.SaveChanges();

            return RedirectToAction("Profile", "Account");
        }

        public IActionResult Profile()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userEmail))
                return Unauthorized();

            var user = _context.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.Legos)
                .FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
                return Unauthorized();

            return View(user);
        }


    }
}
