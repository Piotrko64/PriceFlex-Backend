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

        public readonly ScrapperDbContext _context;

        public AccountService(ScrapperDbContext context)
        {
            _context = context;
        }

        public void RegisterUser(RegisterUserDto registerUserDto)
        {

            var newUser = new User()
            {
                Email = registerUserDto.Email,
                Password = registerUserDto.Password,
                Role = registerUserDto.Role,
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

        }




    }
}
