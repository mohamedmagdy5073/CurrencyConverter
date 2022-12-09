using Application.ExchangesHistory.Dtos;
using Application.Shared.Dtos;

namespace Application.Currencies.Dtos
{
    public class CurrencyDetailsDto : BaseDto
    {
        public string Name { get; set; }
        public string Sign { get; set; }

        public List<ExchangeHistoryDetailsDto> Exchanges { get; set; }
    }
}
