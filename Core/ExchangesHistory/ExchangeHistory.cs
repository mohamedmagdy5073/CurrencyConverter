using Core.Currencies;
using Core.Shared;

namespace Core.ExchangesHistory
{
    public class ExchangeHistory : AuditableEntity
    {
        public Guid CurrencyId { get; set; }
        public DateTime ExchangeDate { get; set; }
        public double Rate { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
