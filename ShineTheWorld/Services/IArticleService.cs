using ShineTheWorld.Models;

namespace ShineTheWorld.Services;

public interface IArticleService
{
    Article? GetArticleById(string id);
    IEnumerable<Article> GetAllArticles();
    IEnumerable<Article> GetArticlesByCategory(string category);
    IEnumerable<string> GetCategories();
}