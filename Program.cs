using Microsoft.EntityFrameworkCore;
using Stripe;
using LaFabriqueaBriques.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlite("Data Source=app.db"));
builder.Services.AddAuthentication("CookieAuth")
   .AddCookie("CookieAuth", options =>
   {
       options.LoginPath = "/Account/Login";
   });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur d'initialisation: {ex.Message}");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
   name: "createLego",
   pattern: "{controller=Admin}/CreateLego");

app.MapControllerRoute(
   name: "addToCart",
   pattern: "{controller=Store}/AddToCart");

app.Run();