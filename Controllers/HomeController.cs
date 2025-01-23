using System.Diagnostics;
using LaFabriqueaBriques.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        public IActionResult Index(string sort)
        {
            // Récupérer d'abord tous les LEGO
            var legos = _context.Legos.ToList();

            // Effectuer le tri en mémoire
            switch (sort)
            {
                case "name-asc":
                    legos = legos.OrderBy(l => l.Name).ToList();
                    break;
                case "name-desc":
                    legos = legos.OrderByDescending(l => l.Name).ToList();
                    break;
                case "price-asc":
                    legos = legos.OrderBy(l => l.Price).ToList();
                    break;
                case "price-desc":
                    legos = legos.OrderByDescending(l => l.Price).ToList();
                    break;
                case "pieces-asc":
                    legos = legos.OrderBy(l => l.NbPiece).ToList();
                    break;
                case "pieces-desc":
                    legos = legos.OrderByDescending(l => l.NbPiece).ToList();
                    break;
                default:
                    legos = legos.OrderBy(l => l.Name).ToList();
                    break;
            }

            return View(legos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
