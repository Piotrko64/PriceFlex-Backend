using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceFlex_Backend.Models.dtos.user;
using PriceFlex_Backend.Services;

namespace PriceFlex_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {


            _accountService.RegisterUser(registerUserDto);

            return Ok();

        }


        [HttpPost("login")]
        public ActionResult LoginUser([FromBody] LoginUserDto registerUserDto)
        {

            Console.WriteLine(99);

            var token = _accountService.GenerateJwt(registerUserDto);

            return Ok(token);

        }

        [Authorize]
        [HttpGet("test")]
        public ActionResult test()
        {


            return Ok("test");

        }


    }
}
