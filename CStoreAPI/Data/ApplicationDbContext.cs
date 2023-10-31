using Microsoft.EntityFrameworkCore;
using CStoreAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CStoreAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
        public DbSet<CStoreAPI.Data.Models.Admin>? Admin { get; set; }
    }
}
