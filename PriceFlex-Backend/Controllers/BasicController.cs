using Microsoft.AspNetCore.Mvc;
using PriceFlex_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PriceFlex_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        WebScrapperService _webscrapper;

        public BasicController(WebScrapperService webScrapper)
        {
            _webscrapper = webScrapper;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {
            return _webscrapper.GetPriceByUrlAndClasses("https://www.mediaexpert.pl/komputery-i-tablety/laptopy-i-ultrabooki/laptopy/laptop-lenovo-ideapad-gaming-3-15ach6-15-6-ips-144hz-r5-5500h-16gb-ram-512gb-ssd-geforce-rtx2050", ".main-price .whole");
        }

    }
}
