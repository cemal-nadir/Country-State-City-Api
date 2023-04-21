using Country.Domain.Entities.EF.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Country.Persistence.Mappings.EF.Main
{
    public class TranslationMapping : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.ToTable("Translations");
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired();
            builder.HasIndex(x => new { x.LanguageId, x.CountryId });
            builder.HasOne(x => x.Country).WithMany(x => x.Translations).HasForeignKey(x => x.CountryId);
            builder.HasOne(x => x.Language).WithMany(x => x.Translations).HasForeignKey(x => x.LanguageId);

        }
    }
}
