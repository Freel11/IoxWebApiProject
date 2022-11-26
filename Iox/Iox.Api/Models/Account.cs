namespace Iox.Api.Models;

public class Account {
    public long Id { get; set; }
    public decimal Balance { get; set; }
    public long UserForeignKey { get; set; }
    public User? User { get; set; }
}