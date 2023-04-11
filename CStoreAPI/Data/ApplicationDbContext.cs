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
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Image> Images => Set<Image>();
    }
}
