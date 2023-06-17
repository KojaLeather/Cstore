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

        private readonly ApplicationDbContext _context;

        public HomeController(IFileWork fileWorkService, ApplicationDbContext context)
        {
            _context = context;
            _fileWorkService = fileWorkService;
        }
        [HttpPost]
        public async Task<ActionResult<ImageBase64>>? PostImage(ImageBase64 imageBase64)
        {
            string filepath = _fileWorkService.WriteFile(imageBase64.Base64, imageBase64.FileName);
            Image image = new Image
            {
                FilePath = filepath,
                ProductId = _context.Products.OrderBy(c => c.Id).Select(c => c.Id).Last()
            };
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetImage", new { id = image.Id }, image);
        }
    }
}
