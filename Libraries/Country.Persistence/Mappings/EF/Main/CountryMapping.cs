using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Country.Persistence.Mappings.EF.Main
{
    public class CountryMapping : IEntityTypeConfiguration<Domain.Entities.EF.Main.Country>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.EF.Main.Country> builder)
        {
            builder.ToTable("Countries");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Iso3).HasMaxLength(3).IsRequired(false);
            builder.Property(x => x.NumericCode).HasMaxLength(3).IsRequired(false);
            builder.Property(x => x.Iso2).HasMaxLength(2).IsRequired(false);
            builder.Property(x => x.PhoneCode).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Capital).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Currency).HasMaxLength(2500).IsRequired(false);
            builder.Property(x => x.CurrencyName).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.CurrencySymbol).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Tld).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Native).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Region).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.SubRegion).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Latitude).HasMaxLength(25).IsRequired(false);
            builder.Property(x => x.Longitude).HasMaxLength(25).IsRequired(false);
            builder.Property(x => x.Emoji).HasMaxLength(191).IsRequired(false);
            builder.Property(x => x.EmojiU).HasMaxLength(191).IsRequired(false);
        }
    }
}
