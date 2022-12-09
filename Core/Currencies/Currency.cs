using Core.ExchangesHistory;
using Core.Shared;

namespace Core.Currencies
{
    public class Currency : AuditableEntity
    {

        public string Name { get; set; }
        public string Sign { get; set; }

        public virtual IEnumerable<ExchangeHistory> Exchanges { get; set; }

    }
}
