using ShineTheWorld.Models;

namespace ShineTheWorld.Services;

public class InMemoryUserService : IUserService
{
    private readonly Dictionary<string, UserAccount> _users = new(StringComparer.OrdinalIgnoreCase);
    private readonly IPasswordHashingService _passwordHashingService;

    public InMemoryUserService(IPasswordHashingService passwordHashingService)
    {
        _passwordHashingService = passwordHashingService;
    }

    public UserAccount? FindByEmail(string email) => _users.TryGetValue(email, out var u) ? u : null;

    public UserAccount Register(string email, string password)
    {
        if (_users.ContainsKey(email)) throw new InvalidOperationException("User exists.");
        var hashedPassword = _passwordHashingService.HashPassword(password);
        var user = new UserAccount { Email = email, PasswordHash = hashedPassword, Salt = string.Empty };
        _users[email] = user;
        return user;
    }

    public bool Validate(string email, string password)
        => _users.TryGetValue(email, out var u) && _passwordHashingService.VerifyPassword(password, u.PasswordHash);

    public void ActivateSubscription(string email, TimeSpan duration)
    {
        if (!_users.TryGetValue(email, out var u)) return;
        u.IsSubscribed = true;
        u.SubscriptionExpiry = DateTime.UtcNow.Add(duration);
    }

    public bool IsSubscribed(string email)
        => _users.TryGetValue(email, out var u) && u.IsSubscribed && (u.SubscriptionExpiry == null || u.SubscriptionExpiry > DateTime.UtcNow);

    public DateTime? SubscriptionExpiry(string email)
        => _users.TryGetValue(email, out var u) ? u.SubscriptionExpiry : null;
}