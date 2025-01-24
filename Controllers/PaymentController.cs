using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using LaFabriqueaBriques.Models;

public class PaymentController : Controller
{
    private readonly IConfiguration _configuration;

    public PaymentController(IConfiguration configuration)
    {
        _configuration = configuration;
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
            SuccessUrl = $"{Request.Scheme}://{Request.Host}/Account/Profile",
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
        TempData["Message"] = "Paiement réussi !";
        return RedirectToAction("Index", "Home");
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