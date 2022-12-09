namespace Application.Currencies.Dtos
{
    public class ConvertCurrencyRequestDto
    {
        public Guid FromCurrency { get; set; }
        public Guid ToCurrency { get; set; }
        public double Amount { get; set; }
    }
}
