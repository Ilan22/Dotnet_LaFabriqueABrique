using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class StoreController : Controller
{
    private readonly AppDbContext _context;

    public StoreController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Details(int id)
    {
        var lego = _context.Legos.FirstOrDefault(l => l.Id == id);

        if (lego == null)
        {
            return NotFound();
        }

        return View(lego);
    }

    [HttpPost]
    public IActionResult AddToCart(int legoId)
    {
        // Get the authenticated user's email using ClaimsPrincipal
        var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(userEmail))
            return Unauthorized();

        // Fetch the user with their cart in a single query
        var user = _context.Users
            .Include(u => u.Cart)
            .FirstOrDefault(u => u.Email == userEmail);

        if (user == null)
            return Unauthorized();

        var lego = _context.Legos.Find(legoId);
        if (lego == null)
            return NotFound();

        // Add to cart using Entity Framework tracking
        user.Cart.Add(lego);
        _context.SaveChanges();

        return RedirectToAction("Cart");
    }

    public IActionResult Cart()
    {
        var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(userEmail))
            return Unauthorized();

        var user = _context.Users
            .Include(u => u.Cart)
            .FirstOrDefault(u => u.Email == userEmail);

        if (user == null)
            return Unauthorized();

        return View(user.Cart);
    }

    public IActionResult Cancel()
    {
        return View();
    }
}