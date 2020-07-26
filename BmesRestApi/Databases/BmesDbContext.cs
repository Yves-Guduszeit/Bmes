using BmesRestApi.Models.Addresses;
using BmesRestApi.Models.Carts;
using BmesRestApi.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace BmesRestApi.Databases
{
    public class BmesDbContext : DbContext
    {
        public BmesDbContext(DbContextOptions<BmesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
