using Application.Currencies.Dtos;
using Application.Shared.Dtos;
using Application.Shared.Interfaces;
using Core.Currencies;

namespace Application.Currencies.Interfaces
{
    public interface ICurrencyService : IService<Currency, CurrencyDto, CurrencyDetailsDto, CreateCurrencyDto, UpdateCurrencyDto>
    {
        Task<CurrencyDto> GetCurrencyById(Guid id);
        Task<PagedResponse<CurrencyDto>> GetCurrencyByName(string name, int pageNumber = 1, int pageSize = 20);
        Task<PagedResponse<CurrencyDto>> GetHighestNCurrencies(int pageNumber = 1, int pageSize = 20);
        Task<PagedResponse<CurrencyDto>> GetLowestNCurrencies(int pageNumber = 1, int pageSize = 20);
        Task<PagedResponse<CurrencyImprovementOrFallenDto>> GetMostImprovedCurrenciesByDate(ImprovedCurrenciesByDateRequest improvedCurrenciesByDateRequest, int pageNumber = 1, int pageSize = 20);
        Task<PagedResponse<CurrencyImprovementOrFallenDto>> GetLeastImprovedCurrenciesByDate(ImprovedCurrenciesByDateRequest improvedCurrenciesByDateRequest, int pageNumber = 1, int pageSize = 20);
        Task<ConvertCurrencyResponseDto> ConvertFromCurrencyToAnother(ConvertCurrencyRequestDto convertCurrency);
    }
}
