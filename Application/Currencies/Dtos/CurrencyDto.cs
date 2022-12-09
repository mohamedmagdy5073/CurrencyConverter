using Application.Shared.Dtos;

namespace Application.Currencies.Dtos
{
    public class CurrencyDto : BaseDto
    {
        public string Name { get; set; }
        public string Sign { get; set; }
        public double CurrentRate { get; set; }
    }
}
