using CStoreAPI.Data;
using CStoreAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IFileWork _fileWorkService;

        public HomeController(IFileWork fileWorkService)
        {
            _fileWorkService = fileWorkService;
        }
        [HttpPost]
        public  Task<ActionResult<ImageBase64>>? PostImage(ImageBase64 imageBase64)
        {
            _fileWorkService.WriteFile(imageBase64.Base64, imageBase64.FileName);
            return null;
        }
    }
}
