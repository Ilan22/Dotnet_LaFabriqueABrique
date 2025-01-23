using System.Diagnostics;
using LaFabriqueaBriques.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaFabriqueaBriques.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var legos = _context.Legos.ToList(); // Récupérer tous les LEGO enregistrés
            return View(legos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
