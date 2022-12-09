using Core.Shared;

namespace Core.Currencies
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<IQueryable> GetCurrenciesAsync(string? name = null);
        Task<IQueryable> GetChangeRateInCurrencies(DateTime fromDate, DateTime toDate);
    }
}
