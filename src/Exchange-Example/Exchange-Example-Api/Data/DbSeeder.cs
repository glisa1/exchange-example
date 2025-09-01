using Exchange_Example_Api.Data.Models;

namespace Exchange_Example_Api.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (!db.Stocks.Any())
        {
            db.Stocks.AddRange(
                new Stock { Ticker = "AAPL", Name = "Apple", Price = 2.5325 },
                new Stock { Ticker = "MSFT", Name = "Microsoft", Price = 4.5325 },
                new Stock { Ticker = "GOOGL", Name = "Google", Price = 3.5325 },
                new Stock { Ticker = "AMZN", Name = "Amazon", Price = 6.5325 }
            );
            db.SaveChanges();
        }
    }
}
