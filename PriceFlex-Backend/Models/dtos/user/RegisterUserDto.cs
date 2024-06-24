using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models.dtos.user
{
    public class RegisterUserDto
    {

        public string Email { get; set; }

      
      
        public string Password { get; set; }

        public UserRole Role { get; set; } = UserRole.StandardUser;
    }
}
