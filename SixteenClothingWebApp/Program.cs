using Microsoft.EntityFrameworkCore;
using SixteenClothingWebApp.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=SixteenClothingWebAppDb;Trusted_Connection=true;Encrypt=false");
});

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();