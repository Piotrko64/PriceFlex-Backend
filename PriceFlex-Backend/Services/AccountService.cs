using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PriceFlex_Backend.Data;
using PriceFlex_Backend.Models;
using PriceFlex_Backend.Models.dtos.user;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PriceFlex_Backend.Services
{

    public interface IAccountService
    {
        public void RegisterUser(RegisterUserDto registerUserDto);
        public string GenerateJwt(LoginUserDto loginDto);
    }


    public class AccountService : IAccountService
    {

        private readonly ScrapperDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AccountService(ScrapperDbContext context, IPasswordHasher<User> passwordHasher,IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public void RegisterUser(RegisterUserDto registerUserDto)
        {

            var newUser = new User()
            {
                Email = registerUserDto.Email,
                Role = registerUserDto.Role,
            };


            newUser.Password = _passwordHasher.HashPassword(newUser, registerUserDto.Password);

            _context.Users.Add(newUser);
            _context.SaveChanges();

        }



        public string GenerateJwt(LoginUserDto loginUserDto)
        {

            var user = _context.Users.FirstOrDefault(u => u.Email == loginUserDto.Email);

            if (user is null)
            {
                throw new BadHttpRequestException("Invalid email or password");
            }


            Console.WriteLine(user.Id);

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginUserDto.Password);

            if (result == PasswordVerificationResult.Failed)
            {

                throw new BadHttpRequestException("Invalid email or password");

            }

            Console.WriteLine(result);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Authentication:JwtKey")));
      
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
           
            var expires = DateTime.Now.AddDays(_configuration.GetValue<int>("Authentication:JwtExpires"));

            var token = new JwtSecurityToken(_configuration.GetValue<string>("Authentication:JwtIssuer"), _configuration.GetValue<string>("Authentication:JwtIssuer"), claims, expires: expires, signingCredentials: cred);


            var tokenHandler = new JwtSecurityTokenHandler();


            return tokenHandler.WriteToken(token);
        }




    }
}
