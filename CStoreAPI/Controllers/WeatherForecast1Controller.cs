using CStoreAPI.Data.Models;
using CStoreAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace CStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecast1Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };



        [HttpGet]
        public ImageBinary Get()
        {
            ImageWork imageWork = new();
            return new ImageBinary
            {
                Image = imageWork.ReadFile("sadge.jpg")
            };
        }
    }
}