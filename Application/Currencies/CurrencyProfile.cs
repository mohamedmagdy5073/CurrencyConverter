using Application.Currencies.Dtos;
using AutoMapper;
using Core.Currencies;

namespace Application.Currencies
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            //CreateMap<Currency, CurrencyDto>()
            //    .ForMember(d => d.CurrentRate, o => o.MapFrom(s => s.Exchanges.OrderByDescending(e => e.ExchangeDate).First().Rate));
            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<CreateCurrencyDto, Currency>();
            CreateMap<Currency, CurrencyDetailsDto>();
            CreateMap<UpdateCurrencyDto, Currency>();
        }
    }
}
