using ConsimpleDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleDemo.Data;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity<OrderProduct>();

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Category);

        modelBuilder.Entity<Order>()
            .HasIndex(o => o.UserId);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.BirthDate);
    }
}
