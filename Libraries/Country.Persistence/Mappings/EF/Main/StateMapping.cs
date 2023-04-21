using Country.Domain.Entities.EF.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Country.Persistence.Mappings.EF.Main
{
    public class StateMapping : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States");
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Latitude).HasMaxLength(25).IsRequired(false);
            builder.Property(x => x.Longitude).HasMaxLength(25).IsRequired(false);
            builder.Property(x => x.CountryName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.StateCode).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Type).HasMaxLength(191).IsRequired(false);
            builder.Property(x => x.CountryCode).HasMaxLength(2).IsRequired();
            builder.HasIndex(x => new { x.CountryId, x.Name });
            builder.HasOne(x => x.Country).WithMany(x => x.States).HasForeignKey(x => x.CountryId);
        }
    }
}
