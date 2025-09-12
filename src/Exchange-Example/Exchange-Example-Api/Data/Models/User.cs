namespace Exchange_Example_Api.Data.Models;

public sealed class User
{
    public int Id { get; set; }
    public Guid KeycloakId { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public decimal Balance { get; set; }
    public ICollection<UserStocks> UserStocks { get; set; } = [];
}
