using ShineTheWorld.Models;

namespace ShineTheWorld.Services;

public class InMemoryArticleService : IArticleService
{
    private readonly List<Article> _articles = new()
    {
        new Article
        {
            Id = "1",
            Title = "Breaking: Major Tech Company Announces Revolutionary AI Breakthrough",
            Content = "In a groundbreaking announcement today, leading technology company unveiled their latest artificial intelligence system that promises to transform how we interact with digital devices. The new AI system, developed over three years by a team of 200+ engineers, demonstrates unprecedented capabilities in natural language understanding and real-world problem solving.\n\nThe system can process complex queries, understand context, and provide detailed responses across multiple domains including science, technology, healthcare, and education. Early testing shows remarkable improvements in accuracy and efficiency compared to existing solutions.\n\n\"This represents a fundamental shift in how AI can assist humans in their daily tasks,\" said the company's Chief Technology Officer during the press conference. \"We're not just improving existing technology; we're creating entirely new possibilities for human-AI collaboration.\"\n\nThe announcement has already sent ripples through the tech industry, with competitors scrambling to understand the implications of this breakthrough. Market analysts predict this could reshape the entire AI landscape and influence investment patterns for years to come.\n\nThe technology will be gradually rolled out to consumers starting next quarter, with enterprise solutions following later in the year. The company has also announced partnerships with major educational institutions to explore applications in learning and research.",
            Category = "Technology",
            IsPremium = false,
            PublishedDate = DateTime.UtcNow.AddHours(-2),
            ImageUrl = "https://images.unsplash.com/photo-1677442136019-21780ecad995?w=800&h=400&fit=crop"
        },
        new Article
        {
            Id = "2",
            Title = "Exclusive: Inside the Secret Government Climate Initiative",
            Content = "Our investigation reveals a comprehensive climate action plan that government officials have been developing behind closed doors for the past 18 months. This exclusive report provides unprecedented access to internal documents and interviews with key stakeholders.\n\nThe initiative, codenamed 'Project Green Future,' involves a massive restructuring of national energy policy and represents the most ambitious environmental program in the country's history. Sources close to the project indicate that the plan includes:\n\n• A complete transition to renewable energy sources by 2035\n• Investment of $500 billion in green infrastructure\n• Creation of 2 million new jobs in the clean energy sector\n• Strict new regulations on industrial emissions\n• International partnerships for global climate action\n\nHowever, the plan faces significant political and economic challenges...",
            Category = "Politics",
            IsPremium = true,
            PublishedDate = DateTime.UtcNow.AddHours(-4),
            ImageUrl = "https://images.unsplash.com/photo-1569163139394-de4e4f43e4e5?w=800&h=400&fit=crop"
        },
        new Article
        {
            Id = "3",
            Title = "Stock Market Reaches Historic High Amid Economic Optimism",
            Content = "The stock market closed at an all-time high today, driven by strong corporate earnings and positive economic indicators. The benchmark index gained 2.3% in today's trading session, marking the fifth consecutive day of gains.\n\nInvestors showed renewed confidence following the release of better-than-expected employment data and inflation figures that suggest the economy is stabilizing after months of uncertainty. Technology stocks led the rally, with several major companies reporting record quarterly profits.\n\n\"We're seeing a perfect storm of positive factors,\" explained market analyst Sarah Johnson. \"Strong corporate performance, controlled inflation, and improving consumer confidence are all contributing to this bullish sentiment.\"\n\nThe surge has added approximately $2 trillion to market capitalization over the past month, benefiting millions of investors and retirement accounts. However, some economists warn that the rapid gains may not be sustainable long-term.\n\nKey sectors driving the growth include renewable energy, healthcare technology, and artificial intelligence companies. International markets have also responded positively, with major indices in Europe and Asia posting significant gains.",
            Category = "Business",
            IsPremium = false,
            PublishedDate = DateTime.UtcNow.AddHours(-6),
            ImageUrl = "https://images.unsplash.com/photo-1611974789855-9c2a0a7236a3?w=800&h=400&fit=crop"
        },
        new Article
        {
            Id = "4",
            Title = "World Cup Final: Dramatic Victory in Penalty Shootout",
            Content = "In one of the most thrilling World Cup finals in history, the championship was decided in a dramatic penalty shootout that kept billions of viewers on the edge of their seats. After 120 minutes of intense football that ended 2-2, the match went to penalties where every kick carried the weight of national pride.\n\nThe final showcased exceptional skill from both teams, with spectacular goals, incredible saves, and moments of pure football magic. The first half saw an early goal that set the tone for an attacking display from both sides.\n\nThe second half brought even more drama, with a controversial penalty decision that sparked heated debates among fans and pundits alike. The equalizing goal came in the 89th minute, sending the match into extra time and setting up one of the most memorable conclusions in World Cup history.\n\nDuring the penalty shootout, both goalkeepers made crucial saves, but it was the final kick that sealed the victory and sparked celebrations across the winning nation. The defeated team, despite their loss, was praised for their incredible journey to the final and their display of sportsmanship throughout the tournament.",
            Category = "Sports",
            IsPremium = false,
            PublishedDate = DateTime.UtcNow.AddHours(-8),
            ImageUrl = "https://images.unsplash.com/photo-1574629810360-7efbbe195018?w=800&h=400&fit=crop"
        },
        new Article
        {
            Id = "5",
            Title = "Medical Breakthrough: New Treatment Shows Promise for Rare Disease",
            Content = "Researchers at leading medical institutions have announced a significant breakthrough in treating a rare genetic disorder that affects thousands of patients worldwide. The new treatment approach has shown remarkable results in clinical trials, offering hope to families who have long awaited effective therapeutic options.\n\nThe innovative therapy targets the root cause of the disease at the cellular level, using advanced gene editing techniques to correct the underlying genetic defect. In Phase II trials, 85% of patients showed significant improvement in symptoms, with many experiencing complete remission.\n\n\"This represents a paradigm shift in how we approach rare genetic diseases,\" said Dr. Maria Rodriguez, lead researcher on the project. \"We're not just treating symptoms anymore; we're addressing the fundamental cause of the condition.\"\n\nThe treatment involves a series of carefully designed interventions that work together to restore normal cellular function...",
            Category = "Health",
            IsPremium = true,
            PublishedDate = DateTime.UtcNow.AddHours(-12),
            ImageUrl = "https://images.unsplash.com/photo-1559757148-5c350d0d3c56?w=800&h=400&fit=crop"
        },
        new Article
        {
            Id = "6",
            Title = "Celebrity Couple Announces Surprise Wedding in Private Ceremony",
            Content = "In a surprise announcement that has delighted fans worldwide, two of Hollywood's biggest stars revealed they tied the knot in an intimate ceremony last weekend. The couple, who have been dating for two years, chose to keep their wedding private, inviting only close family and friends.\n\nThe ceremony took place at a secluded vineyard, with stunning views and a romantic atmosphere that perfectly captured the couple's love story. Photos shared on social media show the bride in an elegant, custom-designed gown and the groom in a classic tuxedo, both beaming with happiness.\n\n\"We wanted our wedding to be about us and our love, not about the spectacle,\" the couple said in a joint statement. \"Having our closest loved ones there to witness our vows was all we needed to make it perfect.\"\n\nThe surprise wedding has generated massive excitement on social media, with fans and fellow celebrities flooding the couple's posts with congratulations and well-wishes. The newlyweds are reportedly planning a honeymoon in Europe before returning to their respective film projects.",
            Category = "Entertainment",
            IsPremium = false,
            PublishedDate = DateTime.UtcNow.AddHours(-16),
            ImageUrl = "https://images.unsplash.com/photo-1511285560929-80b456fea0bc?w=800&h=400&fit=crop"
        },
        new Article
        {
            Id = "7",
            Title = "Exclusive Investigation: Corporate Tax Avoidance Schemes Exposed",
            Content = "A months-long investigation by our financial reporting team has uncovered sophisticated tax avoidance schemes used by several multinational corporations to minimize their tax obligations. The investigation reveals complex networks of offshore entities and financial instruments designed to shift profits away from high-tax jurisdictions.\n\nOur analysis of leaked financial documents shows that these companies have collectively avoided paying billions in taxes over the past five years, using legal but ethically questionable strategies that exploit loopholes in international tax law.\n\nThe schemes involve:\n• Complex ownership structures spanning multiple countries\n• Intellectual property licensing arrangements\n• Strategic debt placement to maximize tax deductions\n• Profit shifting through transfer pricing mechanisms\n\nTax experts describe these arrangements as technically legal but contrary to the spirit of tax law...",
            Category = "Business",
            IsPremium = true,
            PublishedDate = DateTime.UtcNow.AddDays(-1),
            ImageUrl = "https://images.unsplash.com/photo-1554224155-6726b3ff858f?w=800&h=400&fit=crop"
        },
        new Article
        {
            Id = "8",
            Title = "Space Mission Successfully Lands on Mars, Begins Scientific Operations",
            Content = "The international space mission to Mars has achieved a major milestone with the successful landing of its robotic explorer on the Red Planet's surface. After a seven-month journey through space, the sophisticated rover touched down safely and has begun its scientific mission to search for signs of ancient life.\n\nThe landing, described by mission controllers as 'textbook perfect,' was the culmination of years of planning and represents one of the most ambitious space exploration projects ever undertaken. The rover is equipped with advanced scientific instruments capable of analyzing soil samples, atmospheric conditions, and geological formations.\n\nEarly images transmitted back to Earth show a stark but fascinating landscape, with unique rock formations and evidence of ancient water activity. The mission team is particularly excited about several promising locations identified for detailed study.\n\n\"This is just the beginning of what we hope will be groundbreaking discoveries about Mars and its potential to have supported life,\" said Mission Director Dr. James Chen. \"Every piece of data we collect brings us closer to answering fundamental questions about our place in the universe.\"",
            Category = "Science",
            IsPremium = false,
            PublishedDate = DateTime.UtcNow.AddDays(-2),
            ImageUrl = "https://images.unsplash.com/photo-1446776653964-20c1d3a81b06?w=800&h=400&fit=crop"
        }
    };

    public Article? GetArticleById(string id)
    {
        return _articles.FirstOrDefault(a => a.Id == id);
    }

    public IEnumerable<Article> GetAllArticles()
    {
        return _articles;
    }

    public IEnumerable<Article> GetArticlesByCategory(string category)
    {
        return _articles.Where(a => a.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<string> GetCategories()
    {
        return _articles.Select(a => a.Category).Distinct().OrderBy(c => c);
    }
}