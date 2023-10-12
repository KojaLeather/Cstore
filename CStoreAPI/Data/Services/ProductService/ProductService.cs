using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CStoreAPI.Data.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMemoryCache _cache;
        private readonly ApplicationDbContext _context;

        public ProductService(IMemoryCache cache, ApplicationDbContext context)
        {
            _cache = cache;
            _context = context;
        }

        public async Task<int> GetProductCount()
        {
            if(!_cache.TryGetValue("ProductCount", out int count))
            {
                count = await _context.Products.CountAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                };
                _cache.Set("Product", count, cacheEntryOptions);
            }
            return count;
        }
    }
}
