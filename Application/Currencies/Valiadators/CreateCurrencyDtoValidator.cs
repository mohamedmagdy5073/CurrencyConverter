using Application.Currencies.Dtos;
using FluentValidation;

namespace Application.Currencies.Valiadators
{
    public class CreateCurrencyDtoValidator : AbstractValidator<CreateCurrencyDto>
    {
        public CreateCurrencyDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Rate).NotEmpty().NotNull().Must(x => x > 0);
            RuleFor(x => x.Sign).NotEmpty().NotNull().MaximumLength(15);
        }
    }
}
