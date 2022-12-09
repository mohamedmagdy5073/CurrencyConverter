using Application.Identity.Dtos;
using FluentValidation;

namespace Application.Identity.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email).EmailAddress().MaximumLength(128);
            RuleFor(x => x.Password).NotEmpty().NotNull().MaximumLength(256);
        }
    }
}
