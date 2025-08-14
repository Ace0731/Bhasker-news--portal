using Microsoft.AspNetCore.Authentication.Cookies;
using ShineTheWorld.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// Cookie Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {
        o.LoginPath = "/Account/Login";
        o.AccessDeniedPath = "/Account/AccessDenied";
        o.ExpireTimeSpan = TimeSpan.FromDays(30);
        o.SlidingExpiration = true;
    });

// Sessions
builder.Services.AddSession();

// In-memory services (mock data)
builder.Services.AddSingleton<IArticleService, InMemoryArticleService>();
builder.Services.AddSingleton<IUserService, InMemoryUserService>();

// Password hashing service
builder.Services.AddSingleton<IPasswordHashingService, BCryptPasswordHashingService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
