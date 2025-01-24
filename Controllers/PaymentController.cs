using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using LaFabriqueaBriques.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class PaymentController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public PaymentController(
        IConfiguration configuration,
        AppDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCheckoutSession([FromBody] List<Lego> panier)
    {
        if (panier == null || !panier.Any())
        {
            return BadRequest("Le panier est vide");
        }

        StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = panier.Select(lego => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "eur",
                    UnitAmount = (long)(lego.Price * 100),
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = lego.Name,
                        Description = lego.Description
                    }
                },
                Quantity = 1
            }).ToList(),
            Mode = "payment",
            SuccessUrl = $"{Request.Scheme}://{Request.Host}/Payment/Success",
            CancelUrl = $"{Request.Scheme}://{Request.Host}/Store/Cancel"
        };

        try
        {
            var service = new SessionService();
            var session = await service.CreateAsync(options);
            return Json(new { url = session.Url });
        }
        catch (StripeException e)
        {
            return BadRequest(new { error = e.Message });
        }
    }

    public IActionResult Success()
    {
        var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(userEmail))
            return Unauthorized();

        var user = _context.Users
            .Include(u => u.Cart)
            .FirstOrDefault(u => u.Email == userEmail);

        if (user == null || !user.Cart.Any())
            return RedirectToAction("Profile", "Account");

        // Créer la nouvelle commande
        var order = new Order
        {
            UserId = user.Id,
            OrderDate = DateTime.UtcNow,
            TotalPrice = user.Cart.Sum(lego => lego.Price),
            Legos = new List<Lego>(user.Cart)
        };

        // Sauvegarder la commande
        _context.Orders.Add(order);

        // Vider le panier
        user.Cart.Clear();
        _context.SaveChanges();

        TempData["Message"] = "Paiement réussi !";
        return RedirectToAction("Profile", "Account");
    }

    public IActionResult Cancel()
    {
        TempData["Error"] = "Paiement annulé";
        return RedirectToAction("Index", "Cart");
    }

    [HttpPost]
    public async Task<IActionResult> WebhookHandler()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        try
        {
            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                _configuration["Stripe:WebhookSecret"]
            );

            if (stripeEvent.Type == "checkout.session.completed")
            {
                var session = stripeEvent.Data.Object as Session;
                // Logique de traitement post-paiement
            }

            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}