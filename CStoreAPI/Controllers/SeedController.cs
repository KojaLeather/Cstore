/*using System.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CStoreAPI.Data;
using CStoreAPI.Data.Models;


namespace CStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public SeedController(ApplicationDbContext context, IWebHostEnvironment env, IConfiguration configuration)
        {
            _context = context;
            _env = env;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<ActionResult> Import()
        {
            string[] title = { "Black TShirt", "White TShirt", "LongSleeve Xan", "Ahegao Hoodie", "Black Russian Hat" };
            string[] description = { "Regular Cotton Black TShirt", "Regular Cotton White TShirt", "Longsleeve with alprazolam ad", "Hoodie for Cringe people", "Cool hat of local textile factory" };
            int[] cost = { 2000, 1800, 3000, 5000, 2000 };
            int[] quantity = { 5, 5, 5, 5, 5 };
            int i = 0;
            while (i < 5)
            {
                var product = new Product
                {
                    Title = title[i],
                    Description = description[i],
                    Cost = cost[i],
                    Quantity = quantity[i]
                };
                await _context.Products.AddAsync(product);
                i++;
            }
            await _context.SaveChangesAsync();
            string[] name = { "Black TShirt", "White TShirt", "LongSleeve Xan", "Ahegao Hoodie", "Black Russian Hat" };
            string path = "D:\\Programming\\FirstPetProject\\FileStorage\\Images";
            string[] filePath = { "BTs.jpg", "WTs.jpg", "LSx.jpg", "AGH.jpg", "BRH.jpg" };
            int[] productId = { 1, 2, 3, 4, 5 };
            int j = 0;
            while (j < 5)
            {
                var image = new Image
                {
                    Name = name[j],
                    FilePath = Path.Combine(path, filePath[j]),
                    ProductId = productId[j]
                };
                await _context.Images.AddAsync(image);
                j++;
            }
            await _context.SaveChangesAsync();
            return new JsonResult(new
            {
                ProductAdded = i,
                ImageAdded = j
            });
        }
    }
}
*/