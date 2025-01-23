using Microsoft.AspNetCore.Mvc;

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
}