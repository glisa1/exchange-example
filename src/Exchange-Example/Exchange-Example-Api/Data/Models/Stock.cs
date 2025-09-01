namespace Exchange_Example_Api.Data.Models;

public sealed record Stock(
    int Id,
    string Ticker,
    string Name,
    decimal Price)
{
    public override string ToString() => $"Stocks(Ticker: {Ticker}, Name: {Name}, Price: {Price})";
}

// Leave the price here for now. When updating it can also be updated here.
