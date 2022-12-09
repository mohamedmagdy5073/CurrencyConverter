using Core.Currencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Peresistence.Currencies
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Sign).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.Exchanges).WithOne(x => x.Currency).HasForeignKey(x => x.CurrencyId);
            builder.HasIndex(x => x.Name);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
