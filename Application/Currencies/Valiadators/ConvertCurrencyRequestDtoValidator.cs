using Application.Currencies.Dtos;
using FluentValidation;

namespace Application.Currencies.Valiadators
{
    public class ConvertCurrencyRequestDtoValidator : AbstractValidator<ConvertCurrencyRequestDto>
    {
        public ConvertCurrencyRequestDtoValidator()
        {
            RuleFor(x => x.FromCurrency).NotEmpty().NotNull();
            RuleFor(x => x.ToCurrency).NotEmpty().NotNull();
            RuleFor(x => x.Amount).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
