namespace Application.Currencies.Dtos
{
    public class CreateCurrencyDto
    {
        public string Name { get; set; }
        public string Sign { get; set; }
        public double Rate { get; set; }
    }
}
