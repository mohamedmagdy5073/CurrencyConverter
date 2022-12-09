using Application.Currencies.Dtos;
using Core.Currencies;
using Infrastructure.Peresistence.Data;
using Infrastructure.Peresistence.Shared;

namespace Infrastructure.Peresistence.Currencies
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<IQueryable> GetCurrenciesAsync(string? name = null)
        {
            IQueryable<Currency> currencies;

            if (name is not null)
                currencies = await GetRangeAsync(a => a.Name.ToLower().Contains(name.ToLower()));
            else
                currencies = await GetRangeAsync();

            return SelectCurrenciesWithItsLastRateToDto(currencies);
        }

        private IQueryable<CurrencyDto> SelectCurrenciesWithItsLastRateToDto(IQueryable<Currency> currencies)
        {
            return currencies.Select(b => new CurrencyDto
            {
                Id = b.Id,
                Name = b.Name,
                Sign = b.Sign,
                CurrentRate = b.Exchanges.OrderByDescending(c => c.ExchangeDate).Select(e => e.Rate).First()
            });
        }


        public async Task<IQueryable> GetChangeRateInCurrencies(DateTime fromDate, DateTime toDate)
        {
            IQueryable<Currency> currencies = await GetRangeAsync();

            return SelectChangeRateInCurrenciesDto(currencies, fromDate, toDate);
        }

        private IQueryable<CurrencyImprovementOrFallenDto> SelectChangeRateInCurrenciesDto(IQueryable<Currency> currencies,
                                                                                           DateTime fromDate, DateTime toDate)
        {
            return currencies.Select(a => new CurrencyImprovementOrFallenDto()
            {
                Id = a.Id,
                Name = a.Name,
                Sign = a.Sign,
                CurrentRate = a.Exchanges.OrderByDescending(c => c.ExchangeDate).Select(e => e.Rate).First(),

                ChangeRate = a.Exchanges.Where(b => (b.ExchangeDate >= fromDate) &&
                                                        (b.ExchangeDate <= toDate))
                                        .OrderByDescending(c => c.ExchangeDate).Select(e => e.Rate).First()

                            - (a.Exchanges.Where(b => (b.ExchangeDate >= fromDate) &&
                                                        (b.ExchangeDate <= toDate))
                                        .OrderByDescending(c => c.ExchangeDate).Select(e => e.Rate).Last())
            });
        }
    }
}
