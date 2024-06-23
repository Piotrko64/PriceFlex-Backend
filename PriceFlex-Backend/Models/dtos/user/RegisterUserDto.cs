using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models.dtos.user
{
    public class RegisterUserDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [MinLength(8)]
        [RegularExpression(
        @"^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character."
    )]
        public string Password { get; set; }

        public UserRole Role { get; set; } = UserRole.StandardUser;
    }
}
