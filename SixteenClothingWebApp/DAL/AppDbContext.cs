using Microsoft.EntityFrameworkCore;
using SixteenClothingWebApp.Models;
using SixteenClothingWebApp.Models;

namespace SixteenClothingWebApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slide> Sliders { get; set; }
    }
}
