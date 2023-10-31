using CStoreAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CStoreAPI.Data.Services.AdminManage
{
    public class AdminManage : IAdminManage
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        string role_Administrator = "Administrator";

        public AdminManage(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<string> CreateAdmin(string email, string password)
        {
            if (await _userManager.FindByNameAsync(email) == null)
            {
                var user_Admin = new ApplicationUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = email,
                    Email = email
                };
                await _userManager.CreateAsync(user_Admin, password);
                await _userManager.AddToRoleAsync(user_Admin, role_Administrator);

                user_Admin.EmailConfirmed = true;
                user_Admin.LockoutEnabled = false;

                await _context.SaveChangesAsync();

                return new string("Successful");
            }
            else return new string("Error: Admin already exist");
        }
    }
}
