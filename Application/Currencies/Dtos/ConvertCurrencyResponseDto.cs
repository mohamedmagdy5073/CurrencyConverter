namespace Application.Currencies.Dtos
{
    public class ConvertCurrencyResponseDto
    {
        public double AmountOfFromCurrency { get; set; }
        public string FromCurrency { get; set; }
        public double AmountOfToCurrency { get; set; }
        public string ToCurrency { get; set; }
        public string Summary { get; set; }
    }
}
