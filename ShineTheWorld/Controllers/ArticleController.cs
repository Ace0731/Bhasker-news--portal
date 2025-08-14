using Microsoft.AspNetCore.Mvc;
using ShineTheWorld.Models;
using ShineTheWorld.Services;

namespace ShineTheWorld.Controllers;

public class ArticleController : Controller
{
    private readonly IArticleService _articleService;
    private readonly IUserService _userService;

    public ArticleController(IArticleService articleService, IUserService userService)
    {
        _articleService = articleService;
        _userService = userService;
    }

    public IActionResult Details(string id)
    {
        var article = _articleService.GetArticleById(id);
        if (article == null)
        {
            return NotFound();
        }

        var isAuthenticated = User.Identity?.IsAuthenticated == true;
        var userEmail = User.Identity?.Name;
        var isSubscribed = isAuthenticated && userEmail != null && _userService.IsSubscribed(userEmail);

        var viewModel = new ArticleViewModel
        {
            Article = article,
            IsSubscribed = isSubscribed,
            PreviewText = article.IsPremium && !isSubscribed ? article.GetPreviewText(300) : article.Content
        };

        return View(viewModel);
    }
}