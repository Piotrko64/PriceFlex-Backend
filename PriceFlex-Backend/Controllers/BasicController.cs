using Microsoft.AspNetCore.Mvc;
using PriceFlex_Backend.Data;
using PriceFlex_Backend.Models;
using PriceFlex_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PriceFlex_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        private readonly WebScrapperService _webscrapper;
        private readonly EmailSenderService _emailSenderService;
        private readonly ScrapperDbContext _scrapperDbContext;
        private readonly ILogger<BasicController> _logger;

        public BasicController(WebScrapperService webScrapper, ILogger<BasicController> logger,  EmailSenderService emailSenderService, ScrapperDbContext scrapperDbContext)
        {
            _webscrapper = webScrapper;
            _logger = logger;
            _emailSenderService = emailSenderService;
            _scrapperDbContext = scrapperDbContext;
        }

        [HttpGet]
        [ResponseCache(Duration = 1000)]
        public async Task<OkResult> Get()
        {
            Console.WriteLine(_logger);

          


            var ab= _scrapperDbContext.Users.Add(new User()
            {
                Role = UserRole.Admin,
                Email = "",


            });

            _scrapperDbContext.SaveChanges();
  

            await _emailSenderService.SendEmailAsync("Piotrko64@gmail.com", "TEMAT", "<h1>AAAA</h1>");
          
            return Ok();
        }

    }
}
