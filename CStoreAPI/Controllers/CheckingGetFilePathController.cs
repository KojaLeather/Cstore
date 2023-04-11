using CStoreAPI.Data;
using CStoreAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class CheckingGetFilePathController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CheckingGetFilePathController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
    }
}
/*
        [HttpGet]
        public async Task<ActionResult> GetFilePath()
        {
            ImageWork readFile = new ImageWork();
            string name = "sadge.jpg";
            byte[] bytes = readFile.ReadImage(name);
            readFile.WriteImage(bytes, name);
            return new JsonResult(new
            {
                StatusCode = 200
            });
        }
    }
}
*/