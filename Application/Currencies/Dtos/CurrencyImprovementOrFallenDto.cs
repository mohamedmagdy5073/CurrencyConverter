using Application.Shared.Dtos;

namespace Application.Currencies.Dtos
{
    public class CurrencyImprovementOrFallenDto : BaseDto
    {
        public string Name { get; set; }
        public string Sign { get; set; }
        public double CurrentRate { get; set; }
        public double ChangeRate { get; set; }
    }
}
