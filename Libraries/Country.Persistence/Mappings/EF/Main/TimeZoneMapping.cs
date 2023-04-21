using Country.Domain.Entities.EF.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Country.Persistence.Mappings.EF.Main
{
    public class TimeZoneMapping : IEntityTypeConfiguration<Timezone>
    {
        public void Configure(EntityTypeBuilder<Timezone> builder)
        {
            builder.ToTable("Timezones");
            builder.Property(x => x.ZoneName).HasMaxLength(255);
            builder.Property(x => x.GmtOffsetName).HasMaxLength(255);
            builder.Property(x => x.Abbreviation).HasMaxLength(10);
            builder.Property(x => x.TzName).HasMaxLength(255).IsRequired();
            builder.HasOne(x => x.Country).WithMany(x => x.Timezones).HasForeignKey(x => x.CountryId);
        }
    }
}
