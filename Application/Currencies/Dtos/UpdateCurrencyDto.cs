namespace Application.Currencies.Dtos
{
    public class UpdateCurrencyDto
    {
        public string Name { get; set; }
        public string Sign { get; set; }
        public double CurrentRate { get; set; }
        public DateTime DateOfExchange { get; set; }
    }
}
