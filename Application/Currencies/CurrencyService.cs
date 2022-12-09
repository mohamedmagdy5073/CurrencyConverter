using Application.Currencies.Dtos;
using Application.Currencies.Interfaces;
using Application.Extensions;
using Application.Shared;
using Application.Shared.Dtos;
using Application.Shared.Helpers;
using AutoMapper;
using Core.Currencies;
using Core.ExchangesHistory;
using Core.Shared;
using Core.Shared.Exceptions;

namespace Application.Currencies
{
    public class CurrencyService : Service<Currency, CurrencyDto, CurrencyDetailsDto, CreateCurrencyDto, UpdateCurrencyDto>, ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IExchangeHistoryRepository _historyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository,
                               IExchangeHistoryRepository historyRepository,
                               IMapper mapper, IUnitOfWork unitOfWork) : base(currencyRepository, mapper, unitOfWork)
        {
            _currencyRepository = currencyRepository;
            _historyRepository = historyRepository;
        }


        public override async Task<PagedResponse<CurrencyDto>> GetAllAsync(int pageNumber = 1, int pageSize = 20)
        {
            var currencies = (await _currencyRepository.GetCurrenciesAsync())
                .OfType<CurrencyDto>()
                .OrderBy(a => a.Name);

            if (currencies is null)
                throw new NotFoundException("Not found entities");

            return (await PagedList<CurrencyDto>.ToPagedListAsync(currencies, pageNumber, pageSize))
                .ToPagedResponse();
        }


        public async Task<CurrencyDto> GetCurrencyById(Guid id)
        {
            var currency = (await _currencyRepository.GetCurrenciesAsync())
                .OfType<CurrencyDto>()
                .SingleOrDefault(c => c.Id == id);

            return currency is not null
                ? currency
                : throw new NotFoundException("No entity by this id!");
        }


        public async Task<PagedResponse<CurrencyDto>> GetCurrencyByName(string name,
                                                                        int pageNumber = 1, int pageSize = 20)
        {
            var currencies = (await _currencyRepository.GetCurrenciesAsync(name))
                .OfType<CurrencyDto>()
                .OrderBy(a => a.Name);

            if (currencies is null)
                throw new NotFoundException("Not found entities by this name!");

            return (await PagedList<CurrencyDto>.ToPagedListAsync(currencies, pageNumber, pageSize))
                .ToPagedResponse();
        }


        public override async Task<CurrencyDto> CreateAsync(CreateCurrencyDto entity)
        {
            var createdCurrency = await base.CreateAsync(entity);
            createdCurrency.CurrentRate = entity.Rate;

            await _historyRepository.InsertAsync(PrepareExchangeHistory(createdCurrency));
            
            return await _unitOfWork.CommitAsync() > 0 
                ? createdCurrency 
                : throw new BadRequestException("Something went wrong!") ;
        }

        private ExchangeHistory PrepareExchangeHistory(CurrencyDto createdCurrency)
        {
            return new ExchangeHistory()
            {
                CurrencyId = createdCurrency.Id,
                ExchangeDate = DateTime.Now,
                Rate = createdCurrency.CurrentRate
            };
        }


        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);

            var exchanges = await _historyRepository.GetRangeAsync(a => a.CurrencyId == id);
            _historyRepository.DeleteRange(exchanges);

            if (await _unitOfWork.CommitAsync() <= 0)
                throw new BadRequestException("Something went wrong!");
        }


        public override async Task<CurrencyDto> UpdateAsync(Guid id, UpdateCurrencyDto entity)
        {
            var currency = await _currencyRepository.GetByIdAsync(id);

            if (currency is null)
                throw new NotFoundException("No entity by this id!");

            UpdateExchangeIfNeeded(currency, entity);

            var updatedEntity = await base.UpdateAsync(id, entity);
            updatedEntity.CurrentRate = entity.CurrentRate;

            return await _unitOfWork.CommitAsync() > 0
                ? updatedEntity
                : throw new BadRequestException("Something went wrong!");
        }

        private async Task UpdateExchangeIfNeeded(Currency currency, UpdateCurrencyDto entity)
        {
            if (!currency.Exchanges.Any(e => e.ExchangeDate == entity.DateOfExchange))
            {
                await _historyRepository.InsertAsync(new ExchangeHistory()
                {
                    ExchangeDate = entity.DateOfExchange,
                    Rate = entity.CurrentRate,
                    CurrencyId = currency.Id
                });
            }
        }


        public async Task<PagedResponse<CurrencyDto>> GetHighestNCurrencies(int pageNumber = 1, int pageSize = 20)
        {
            var currencies = (await _currencyRepository.GetCurrenciesAsync())
                .OfType<CurrencyDto>()
                .OrderByDescending(a => a.CurrentRate);

            if (currencies is null)
                throw new NotFoundException("Not found entities");

            return (await PagedList<CurrencyDto>.ToPagedListAsync(currencies, pageNumber, pageSize))
                .ToPagedResponse();
        }


        public async Task<PagedResponse<CurrencyDto>> GetLowestNCurrencies(int pageNumber = 1, int pageSize = 20)
        {
            var currencies = (await _currencyRepository.GetCurrenciesAsync())
                .OfType<CurrencyDto>()
                .OrderBy(a => a.CurrentRate);

            if (currencies is null)
                throw new NotFoundException("Not found entities");

            return (await PagedList<CurrencyDto>.ToPagedListAsync(currencies, pageNumber, pageSize))
                .ToPagedResponse();
        }


        public async Task<PagedResponse<CurrencyImprovementOrFallenDto>> GetMostImprovedCurrenciesByDate(ImprovedCurrenciesByDateRequest
                                                                                         improvedCurrenciesByDateRequest, int pageNumber = 1, int pageSize = 20)
        {
            IQueryable<CurrencyImprovementOrFallenDto> currencies;

            currencies = (await _currencyRepository.GetChangeRateInCurrencies(improvedCurrenciesByDateRequest.FromDate, improvedCurrenciesByDateRequest.ToDate))
                .OfType<CurrencyImprovementOrFallenDto>()
                .Where(a => a.ChangeRate > 0)
                .OrderByDescending(a => a.ChangeRate);

            if (currencies is null)
                throw new NotFoundException("Not found entities");

            return (await PagedList<CurrencyImprovementOrFallenDto>.ToPagedListAsync(currencies, pageNumber, pageSize))
                .ToPagedResponse();
        }


        public async Task<PagedResponse<CurrencyImprovementOrFallenDto>> GetLeastImprovedCurrenciesByDate(ImprovedCurrenciesByDateRequest
                                                                                         improvedCurrenciesByDateRequest, int pageNumber = 1, int pageSize = 20)
        {
            IQueryable<CurrencyImprovementOrFallenDto> currencies;

            currencies = (await _currencyRepository.GetChangeRateInCurrencies(improvedCurrenciesByDateRequest.FromDate, improvedCurrenciesByDateRequest.ToDate))
                .OfType<CurrencyImprovementOrFallenDto>()
                .Where(a => a.ChangeRate > 0)
                .OrderBy(a => a.ChangeRate);

            if (currencies is null)
                throw new NotFoundException("Not found entities");

            return (await PagedList<CurrencyImprovementOrFallenDto>.ToPagedListAsync(currencies, pageNumber, pageSize))
                .ToPagedResponse();
        }


        public async Task<ConvertCurrencyResponseDto> ConvertFromCurrencyToAnother(ConvertCurrencyRequestDto convertCurrency)
        {
            var fromCurrency = (await _currencyRepository.GetCurrenciesAsync())
                .OfType<CurrencyDto>()
                .SingleOrDefault(a => a.Id == convertCurrency.FromCurrency);

            var toCurrency = (await _currencyRepository.GetCurrenciesAsync())
                .OfType<CurrencyDto>()
                .SingleOrDefault(a => a.Id == convertCurrency.ToCurrency);

            if (fromCurrency is null || toCurrency is null)
                throw new NotFoundException("one of your currencies or both was not found please check ids again!");

            var convertedAmount = ConvertTo(convertCurrency.Amount, fromCurrency.CurrentRate, toCurrency.CurrentRate);

            return PrepareConvertCurrencyResponse(fromCurrency , convertCurrency.Amount, toCurrency, convertedAmount);
        }

        private static double ConvertTo(double amountOfCurrency, double fromCurrencyRate, double toCurrencyRate)
        {
            return Math.Round(amountOfCurrency * fromCurrencyRate / toCurrencyRate, 3);
        }

        private ConvertCurrencyResponseDto PrepareConvertCurrencyResponse(CurrencyDto fromCurrency, double convertCurrencyAmount,
                                                                          CurrencyDto toCurrency, double convertedAmount)
        {
            return new ConvertCurrencyResponseDto()
            {
                FromCurrency = fromCurrency.Name,
                AmountOfFromCurrency = convertCurrencyAmount,
                ToCurrency = toCurrency.Name,
                AmountOfToCurrency = convertedAmount,
                Summary = $"{convertCurrencyAmount} {fromCurrency.Name}s = {convertedAmount} {toCurrency.Name}s"
            };
        }
    }
}
