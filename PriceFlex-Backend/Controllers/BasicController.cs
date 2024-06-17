using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<BasicController> _logger;

        public BasicController(WebScrapperService webScrapper, ILogger<BasicController> logger,  EmailSenderService emailSenderService)
        {
            _webscrapper = webScrapper;
            _logger = logger;
            _emailSenderService = emailSenderService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<OkResult> Get()
        {
            Console.WriteLine(_logger);

           await  _emailSenderService.SendEmailAsync("Piotrko64@gmail.com", "TEMAT", "<h1>AAAA</h1>");
          
            return Ok();
        }

    }
}
