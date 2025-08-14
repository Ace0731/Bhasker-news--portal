using Microsoft.AspNetCore.Mvc;
using ShineTheWorld.Models;
using ShineTheWorld.Services;
using System.Diagnostics;

namespace ShineTheWorld.Controllers;

public class HomeController(IArticleService articles) : Controller
{
    public IActionResult Index(string? category)
    {
        var model = new HomeViewModel
        {
            Articles = string.IsNullOrEmpty(category) ? articles.GetAllArticles() : articles.GetArticlesByCategory(category),
            ActiveCategory = category,
            Categories = articles.GetCategories()
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}