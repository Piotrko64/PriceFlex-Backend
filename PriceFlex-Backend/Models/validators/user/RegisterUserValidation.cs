using FluentValidation;
using PriceFlex_Backend.Data;
using PriceFlex_Backend.Models.dtos.user;

namespace PriceFlex_Backend.Models.validators.user



{
    public class RegisterUserValidation : AbstractValidator<RegisterUserDto>
    {
 

        public RegisterUserValidation(ScrapperDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().Matches(@"^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,}$");

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var isEmailInUse = dbContext.Users.Any(u => u.Email == value);

                if (isEmailInUse) {
                    context.AddFailure("Email", "This Email is taken");
                }

            });

        }

    }
}
