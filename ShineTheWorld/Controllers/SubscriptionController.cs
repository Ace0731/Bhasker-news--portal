using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShineTheWorld.Services;

namespace ShineTheWorld.Controllers;

[Authorize]
public class SubscriptionController(IUserService users) : Controller
{
    [HttpGet]
    public IActionResult Plans() => View(); // shows plans + QR UI (mock)

    // Demo: pretend Razorpay callback success
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Activate(string plan)
    {
        var email = User.Identity?.Name;
        if (string.IsNullOrEmpty(email))
        {
            return RedirectToAction("Login", "Account");
        }
        var duration = plan switch
        {
            "Monthly" => TimeSpan.FromDays(30),
            "Quarterly" => TimeSpan.FromDays(90),
            "Yearly" => TimeSpan.FromDays(365),
            "Lifetime" => TimeSpan.FromDays(36500),
            _ => TimeSpan.FromDays(30)
        };
        users.ActivateSubscription(email, duration);
        TempData["SubSuccess"] = $"Subscription activated: {plan}";
        return RedirectToAction("Index", "Home");
    }
}
