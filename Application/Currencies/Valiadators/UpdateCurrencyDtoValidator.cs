using Application.Currencies.Dtos;
using FluentValidation;

namespace Application.Currencies.Valiadators
{
    public class UpdateCurrencyDtoValidator : AbstractValidator<UpdateCurrencyDto>
    {
        public UpdateCurrencyDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.CurrentRate).NotEmpty().NotNull().Must(x => x > 0);
            RuleFor(x => x.Sign).NotEmpty().NotNull().MaximumLength(15);
            RuleFor(x => x.DateOfExchange).LessThanOrEqualTo(x => DateTime.Now).NotEmpty().NotNull();
        }
    }
}
