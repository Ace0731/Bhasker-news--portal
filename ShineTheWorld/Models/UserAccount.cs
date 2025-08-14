namespace ShineTheWorld.Models;

public class UserAccount
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = ""; // demo only (we'll switch later)
    public string Salt { get; set; } = "";
    public bool IsSubscribed { get; set; } = false;
    public DateTime? SubscriptionExpiry { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
