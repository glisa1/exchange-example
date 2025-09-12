namespace Exchange_Example_Api.Data.Models;

public sealed class UserStocks
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int StockId { get; set; }
    public Stock Stock { get; set; } = null!;
    public User User { get; set; } = null!;
    public decimal Quantity { get; set; }
}