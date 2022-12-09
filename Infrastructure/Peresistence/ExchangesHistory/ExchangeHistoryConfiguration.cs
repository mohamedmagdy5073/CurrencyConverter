using Core.ExchangesHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Peresistence.ExchangesHistory
{
    public class ExchangeHistoryConfiguration : IEntityTypeConfiguration<ExchangeHistory>
    {

        public void Configure(EntityTypeBuilder<ExchangeHistory> builder)
        {
            builder.Property(x => x.ExchangeDate).IsRequired();
            builder.Property(x => x.Rate).IsRequired();
            builder.HasIndex(x => x.ExchangeDate);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
