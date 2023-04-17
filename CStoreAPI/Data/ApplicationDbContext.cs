using Microsoft.EntityFrameworkCore;
using CStoreAPI.Data.Models;

namespace CStoreAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Image> Images => Set<Image>();
        public DbSet<Order> Orders => Set<Order>();
    }
}
