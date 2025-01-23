using LaFabriqueaBriques.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Lego> Legos { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserLego>()
            .HasKey(ul => new { ul.UserId, ul.LegoId });

        modelBuilder.Entity<UserLego>()
            .HasOne(ul => ul.User)
            .WithMany(u => u.UserLegos)
            .HasForeignKey(ul => ul.UserId);

        //modelBuilder.Entity<UserLego>()
        //    .HasOne(ul => ul.Lego)
        //    .WithMany(l => l.UserLegos)
        //    .HasForeignKey(ul => ul.LegoId);

        modelBuilder.Entity<Order>()
          .HasOne(o => o.User) // Une commande appartient à un utilisateur
          .WithMany(u => u.Orders)
          .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Legos) // Une commande peut contenir plusieurs Legos
            .WithMany(l => l.Orders);
    }
}
