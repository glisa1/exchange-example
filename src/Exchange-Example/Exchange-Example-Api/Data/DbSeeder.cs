using Exchange_Example_Api.Data.Models;

namespace Exchange_Example_Api.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (!db.Stocks.Any())
        {
            db.Stocks.AddRange(
                new Stock { Ticker = "AAPL", Name = "Apple", Price = 2.5325, Description = "Apple Inc. is an American multinational technology company headquartered in Cupertino, California, in Silicon Valley, best known for its consumer electronics, software and online services. Founded in 1976 as Apple Computer Company by Steve Jobs, Steve Wozniak and Ronald Wayne, the company was incorporated by Jobs and Wozniak as Apple Computer, Inc. the following year." },
                new Stock { Ticker = "MSFT", Name = "Microsoft", Price = 4.5325, Description = "Microsoft Corporation is an American multinational technology conglomerate headquartered in Redmond, Washington. Founded in 1975, the company became influential in the rise of personal computers through software like Windows, and has since expanded to Internet services, cloud computing, video gaming and other fields. It is the largest software maker, one of the most valuable public companies,[a] and one of the most valuable brands globally." },
                new Stock { Ticker = "GOOGL", Name = "Google", Price = 3.5325, Description = "Google LLC (/ˈɡuː.ɡəl/ ⓘ, GOO-gəl) is an American multinational technology corporation focused on information technology, online advertising, search engine technology, email, cloud computing, software, quantum computing, e-commerce, consumer electronics, and artificial intelligence (AI)." },
                new Stock { Ticker = "AMZN", Name = "Amazon", Price = 6.5325, Description = "Amazon.com, Inc.,[1] doing business as Amazon,[a] is an American multinational technology company engaged in e-commerce, cloud computing, online advertising, digital streaming, and artificial intelligence.[5] Founded in 1994 by Jeff Bezos in Bellevue, Washington,[6] the company originally started as an online marketplace for books, but gradually expanded its offerings to include a wide range of product categories, referred to as \"The Everything Store\"." }
            );
            db.SaveChanges();
        }
    }
}
