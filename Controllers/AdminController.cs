using Microsoft.AspNetCore.Mvc;
using LaFabriqueaBriques.Models;

namespace LaFabriqueaBriques.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateLego()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateLego(Lego lego, string ImageUrlsInput)
        {
            if (ModelState.IsValid)
            {
                // Séparez les URLs à partir de l'entrée de texte
                lego.ImageUrls = ImageUrlsInput
                    .Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                _context.Legos.Add(lego);
                _context.SaveChanges();
                return RedirectToAction("Index", "Store");
            }
            return View(lego);
        }
        public IActionResult ManageUsers()
        {
            var users = _context.Users.ToList();
            var model = new AdminUserViewModel { Users = users };
            return View(model);
        }

        [HttpPost]
        public IActionResult ChangeRole(int id, int role)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.Role = role;
                _context.SaveChanges();
            }
            return RedirectToAction("ManageUsers");
        }
    }
}
