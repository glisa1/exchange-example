namespace Exchange_Example_Api.Data.Models;

public sealed class Stock
{
    public int Id { get; set; }
    public string Ticker { get; set; } = null!;
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public ICollection<UserStocks> UserStocks { get; set; } = [];
}

// Leave the price here for now. When updating it can also be updated here.
