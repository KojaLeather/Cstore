using System.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CStoreAPI.Data;
using CStoreAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public SeedController(ApplicationDbContext context, IWebHostEnvironment env, IConfiguration configuration, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _env = env;
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
            
        }
        [HttpGet]
        public async Task<ActionResult> Import()
        {
            //Seeding Category Table
            string[] categories = { "TShirts", "Longsleeves", "Hoodies", "Hats" };
            foreach (string category in categories)
            {
                var newCategory = new Category
                {
                    CategoryName = category
                };
                await _context.Categories.AddAsync(newCategory);
            }

            //Seeding Product Table
            string[] title = { "Black TShirt", "White TShirt", "LongSleeve Xan", "Ahegao Hoodie", "Black Russian Hat" };
            string[] description = { "Regular Cotton Black TShirt", "Regular Cotton White TShirt", "Longsleeve with alprazolam ad", "Hoodie for Cringe people", "Cool hat of local textile factory" };
            int[] cost = { 2000, 1800, 3000, 5000, 2000 };
            int[] quantity = { 5, 5, 5, 5, 5 };
            int[] categoryId = { 1, 1, 2, 3, 4 };
            int i = 0;
            while (i < 5)
            {
                var product = new Product
                {
                    Title = title[i],
                    Description = description[i],
                    Cost = cost[i],
                    Quantity = quantity[i],
                    CategoryId = categoryId[i]
                };
                await _context.Products.AddAsync(product);
                i++;
            }
            await _context.SaveChangesAsync();

            //Seeding Image Table
            string path = "\\Images";
            string[] filePath = { "BTs.jpg", "WTs.jpg", "LSx.jpg", "AGH.jpg", "BRH.jpg" };
            int[] productId = { 1, 2, 3, 4, 5 };
            int j = 0;
            while (j < 5)
            {
                var image = new Image
                {
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
        [HttpGet]
        public async Task<ActionResult> CreateDefaultUsers()
        {
            string role_RegisteredUser = "RegisteredUser";
            string role_Administrator = "Administrator";

            if (await _roleManager.FindByNameAsync(role_RegisteredUser) == null)
                await _roleManager.CreateAsync(new IdentityRole(role_RegisteredUser));

            if (await _roleManager.FindByNameAsync(role_Administrator) == null)
                await _roleManager.CreateAsync(new IdentityRole(role_Administrator));

            var addedUserList = new List<ApplicationUser>();

            var email_Admin = "admin@email.com";
            if (await _userManager.FindByNameAsync(email_Admin) == null)
            {
                var user_Admin = new ApplicationUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = email_Admin,
                    Email = email_Admin
                };
                await _userManager.CreateAsync(user_Admin, _configuration["DefaultPassword:Administrator"]);
                await _userManager.AddToRoleAsync(user_Admin, role_RegisteredUser);
                await _userManager.AddToRoleAsync(user_Admin, role_Administrator);

                user_Admin.EmailConfirmed = true;
                user_Admin.LockoutEnabled = false;

                addedUserList.Add(user_Admin);
            }

            var email_User = "user@email.com";
            if (await _userManager.FindByNameAsync(email_User) == null)
            {
                var user_User = new ApplicationUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = email_User,
                    Email = email_User
                };

                await _userManager.CreateAsync(user_User, _configuration["DefaultPassword:RegisteredUser"]);
                await _userManager.AddToRoleAsync(user_User, role_RegisteredUser);

                user_User.EmailConfirmed = true;
                user_User.LockoutEnabled = false;

                addedUserList.Add(user_User);
            }

            if (addedUserList.Count > 0)
                await _context.SaveChangesAsync();

            return new JsonResult(new
            {
                Count = addedUserList.Count,
                Users = addedUserList
            });
        }

    }
}
