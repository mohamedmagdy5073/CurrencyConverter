using Application.ExchangesHistory.Dtos;
using AutoMapper;
using Core.ExchangesHistory;

namespace Application.ExchangesHistory
{
    public class ExchangeHistoryProfile : Profile
    {
        public ExchangeHistoryProfile()
        {
            CreateMap<ExchangeHistory, ExchangeHistoryDetailsDto>();
        }
    }
}
