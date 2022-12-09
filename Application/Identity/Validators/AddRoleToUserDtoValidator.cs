using Application.Identity.Dtos;
using FluentValidation;

namespace Application.Identity.Validators
{
    public class AddRoleToUserDtoValidator : AbstractValidator<AddRoleToUserDto>
    {
        public AddRoleToUserDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.Role).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
