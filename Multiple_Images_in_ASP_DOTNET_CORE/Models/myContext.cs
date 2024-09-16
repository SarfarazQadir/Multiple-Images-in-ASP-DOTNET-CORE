using Microsoft.EntityFrameworkCore;

namespace Multiple_Images_in_ASP_DOTNET_CORE.Models
{
    public class myContext : DbContext
    {
        public myContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductImage> ProductViewModel { get; set; }
    }
}
