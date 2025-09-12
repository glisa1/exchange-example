using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserStocks> UserStocks => Set<UserStocks>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserStocks>().ToTable("user_stocks").HasKey(us => us.Id);
        modelBuilder.Entity<UserStocks>().Property(us => us.UserId).IsRequired();
        modelBuilder.Entity<UserStocks>().HasOne(us => us.Stock).WithMany(s => s.UserStocks).HasForeignKey(us => us.StockId);
        modelBuilder.Entity<UserStocks>().HasOne(us => us.User).WithMany(u => u.UserStocks).HasForeignKey(us => us.UserId);
        modelBuilder.Entity<UserStocks>().Property(us => us.Quantity).IsRequired().HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Stock>().ToTable("stocks").HasKey(s => s.Id);
        modelBuilder.Entity<Stock>().Property(s => s.Ticker).IsRequired().HasMaxLength(10);
        modelBuilder.Entity<Stock>().Property(s => s.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Stock>().Property(s => s.Price).IsRequired().HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Stock>().HasMany(s => s.UserStocks).WithOne(us => us.Stock).HasForeignKey(us => us.StockId);

        modelBuilder.Entity<User>().ToTable("users").HasKey(u => u.Id);
        // Maybe set email to be unique?
        modelBuilder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<User>().Property(u => u.Balance).IsRequired().HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<User>().HasMany(u => u.UserStocks).WithOne(us => us.User).HasForeignKey(us => us.UserId);
        modelBuilder.Entity<User>().Property(u => u.KeycloakId).IsRequired();
    }
}
