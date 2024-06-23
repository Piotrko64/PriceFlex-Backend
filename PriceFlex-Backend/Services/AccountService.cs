using Microsoft.AspNetCore.Identity;
using PriceFlex_Backend.Data;
using PriceFlex_Backend.Models;
using PriceFlex_Backend.Models.dtos.user;

namespace PriceFlex_Backend.Services
{

    public interface IAccountService { 
    public void RegisterUser(RegisterUserDto registerUserDto);
    }

    public class AccountService : IAccountService
    {

        private readonly ScrapperDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(ScrapperDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
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




    }
}
