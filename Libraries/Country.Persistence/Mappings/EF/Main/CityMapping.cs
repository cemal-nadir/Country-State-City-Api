using Country.Domain.Entities.EF.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Country.Persistence.Mappings.EF.Main
{
    public class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.Property(x => x.Name).HasMaxLength(255);
            builder.Property(x => x.StateId).IsRequired();
            builder.Property(x => x.StateCode).HasMaxLength(255).IsRequired();
            builder.Property(x => x.CountryCode).HasMaxLength(2).IsRequired();
            builder.Property(x => x.Latitude).HasMaxLength(25).IsRequired(false);
            builder.Property(x => x.Longitude).HasMaxLength(25).IsRequired(false);
            builder.Property(x => x.WikiDataId).HasMaxLength(255).IsRequired(false);
            builder.HasIndex(x => new { x.CountryId, x.StateId, x.Name });
            builder.HasOne(x => x.State).WithMany(x => x.Cities).HasForeignKey(x => x.StateId);
            builder.HasOne(x => x.Country).WithMany(x => x.Cities).HasForeignKey(x => x.CountryId);
        }
    }
}
