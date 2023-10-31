using Microsoft.AspNetCore.Mvc;
using CStoreAPI.Data;
using CStoreAPI.Data.Models;
using CStoreAPI.Data.Models.DTO;
using CStoreAPI.Data.Services.AdminManage;

namespace CStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class AdminAccountController : Controller
    {
        private readonly AdminManage _adminManage;
        public AdminAccountController(IAdminManage adminManage)
        {
            _adminManage = (AdminManage)adminManage;
        }
        [HttpPost]
        public async Task<ActionResult<Admin>> CreateAdmin([FromBody] Admin admin)
        {
            string result = await _adminManage.CreateAdmin(admin.Email, admin.Password);
            if (result == "Successful")
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}
