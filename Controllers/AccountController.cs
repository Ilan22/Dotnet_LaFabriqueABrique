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

        public IActionResult Edit()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userEmail))
                return Unauthorized();

            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(string newPassword, string confirmPassword)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userEmail))
                return Unauthorized();

            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
                return NotFound();

            // Mise à jour du nom et de l'email
            if (Request.Form.TryGetValue("Name", out var nameValues))
                user.Name = nameValues.ToString();
            
            if (Request.Form.TryGetValue("Email", out var emailValues))
            {
                var newEmail = emailValues.ToString();
                if (newEmail != user.Email && _context.Users.Any(u => u.Email == newEmail))
                {
                    ModelState.AddModelError("Email", "Cet email est déjà utilisé.");
                    return View(user);
                }
                user.Email = newEmail;
            }

            // Mise à jour du mot de passe si fourni
            if (!string.IsNullOrEmpty(newPassword))
            {
                if (newPassword != confirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Les mots de passe ne correspondent pas.");
                    return View(user);
                }
                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            }

            _context.Update(user);
            _context.SaveChanges();

            // Mise à jour des claims si l'email a changé
            if (emailValues.ToString() != userEmail)
            {
                HttpContext.SignOutAsync("CookieAuth");
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Role", user.Role.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));
            }

            return RedirectToAction(nameof(Profile));
        }
    }
}
