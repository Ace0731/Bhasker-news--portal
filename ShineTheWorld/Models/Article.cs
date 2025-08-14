namespace ShineTheWorld.Models;

public class Article
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public string Category { get; set; } = "";
    public bool IsPremium { get; set; } = false;
    public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
    public string Author { get; set; } = "Shine The World Staff";
    public int ReadTimeMinutes { get; set; } = 5;
    
    public string GetPreviewText(int maxLength = 200)
    {
        if (Content.Length <= maxLength) return Content;
        
        var preview = Content.Substring(0, maxLength);
        var lastSpace = preview.LastIndexOf(' ');
        if (lastSpace > 0) preview = preview.Substring(0, lastSpace);
        
        return preview + "...";
    }
}