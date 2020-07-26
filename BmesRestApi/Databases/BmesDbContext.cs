using BmesRestApi.Models.Addresses;
using BmesRestApi.Models.Carts;
using BmesRestApi.Models.Customers;
using BmesRestApi.Models.Products;
using BmesRestApi.Models.Shared;
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
