using Microsoft.AspNetCore.Mvc;

namespace CStoreAPI.Data.Services.AdminManage
{
    public interface IAdminManage
    {
        public Task<string> CreateAdmin(string email, string password);
    }
}
