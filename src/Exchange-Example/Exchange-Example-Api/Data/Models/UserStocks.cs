namespace Exchange_Example_Api.Data.Models;

public sealed record UserStocks(int Id, int UserId, int StockId, decimal Quantity)
{
    public override string ToString() => $"UserStocks(UserId: {UserId}, StockId: {StockId}, Quantity: {Quantity})";
}
