using ShineTheWorld.Models;

namespace ShineTheWorld.Services;

public interface IUserService
{
    UserAccount? FindByEmail(string email);
    UserAccount Register(string email, string password);
    bool Validate(string email, string password);
    void ActivateSubscription(string email, TimeSpan duration);
    bool IsSubscribed(string email);
    DateTime? SubscriptionExpiry(string email);
}
