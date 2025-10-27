using System.ComponentModel.DataAnnotations;

namespace Exchange_Example_Api.Data.Models;

public sealed class Stock
{
    public int Id { get; set; }
    [MaxLength(10)]
    public string Ticker { get; set; } = null!;
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    [MaxLength(500)]
    public string Description { get; set; } = null!;
    public ICollection<UserStocks> UserStocks { get; set; } = [];
}

// Leave the price here for now. When updating it can also be updated here.
