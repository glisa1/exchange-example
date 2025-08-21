using Exchange_Example_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<UserStocks> UserStocks => Set<UserStocks>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserStocks>().ToTable("user_stocks").HasKey(us => us.Id);
        modelBuilder.Entity<UserStocks>().Property(us => us.UserId).IsRequired();
        modelBuilder.Entity<UserStocks>().Property(us => us.StockId).IsRequired();
        modelBuilder.Entity<UserStocks>().Property(us => us.Quantity).IsRequired().HasColumnType("decimal(18, 2)");
    }
}
