using System.ComponentModel.DataAnnotations;

namespace ShineTheWorld.Models;

public class HomeViewModel
{
    public IEnumerable<Article> Articles { get; set; } = Enumerable.Empty<Article>();
    public string? ActiveCategory { get; set; }
    public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();
}

public class ArticleViewModel
{
    public Article Article { get; set; } = new();
    public bool IsSubscribed { get; set; }
    public string PreviewText { get; set; } = "";
}

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = "";
}

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";
}
