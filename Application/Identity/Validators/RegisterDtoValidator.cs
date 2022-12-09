using Application.Identity.Dtos;
using FluentValidation;

namespace Application.Identity.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Username).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Email).EmailAddress().MaximumLength(128);
            RuleFor(x => x.Password).NotEmpty().NotNull().MaximumLength(256);
        }
    }
}
