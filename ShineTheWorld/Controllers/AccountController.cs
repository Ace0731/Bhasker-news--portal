using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ShineTheWorld.Services;
using System.Security.Claims;
using ShineTheWorld.Models;

namespace ShineTheWorld.Controllers;

public class AccountController(IUserService users) : Controller
{
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            users.Register(model.Email, model.Password);
            await SignIn(model.Email);
            return RedirectToAction("Index", "Home");
        }
        catch (InvalidOperationException)
        {
            ModelState.AddModelError("Email", "User already exists.");
            return View(model);
        }
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (users.Validate(model.Email, model.Password))
        {
            await SignIn(model.Email);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid credentials.";
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied() => View();

    private async Task SignIn(string email)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, email)
        };
        var id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(id));
    }
}
