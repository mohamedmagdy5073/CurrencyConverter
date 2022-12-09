using Core.ExchangesHistory;
using Infrastructure.Peresistence.Data;
using Infrastructure.Peresistence.Shared;

namespace Infrastructure.Peresistence.ExchangesHistory
{
    public class ExchangeHistoryRepository : Repository<ExchangeHistory>, IExchangeHistoryRepository
    {
        public ExchangeHistoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
