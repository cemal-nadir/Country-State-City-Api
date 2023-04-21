using Country.Domain.Entities.EF.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Country.Persistence.Mappings.EF.Main
{
    public class LanguageMapping : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Id).HasMaxLength(10);
            builder.HasIndex(x => new { x.Id, x.Description });
            Seed(builder);
        }

        private void Seed(EntityTypeBuilder<Language> builder)
        {
            builder.HasData(
                new Language
                {
                    Id = "kr",
                    Description = "Korean"
                },
                new Language()
                {
                    Id = "pt-BR",
                    Description = "Portuguese (Brazil)"
                },
                new Language()
                {
                    Id = "pt",
                    Description = "Portuguese (Portugal)"
                },
                new Language()
                {
                    Id = "nl",
                    Description = "Dutch"
                },
                new Language()
                {
                    Id = "hr",
                    Description = "Croatian"
                },
                new Language()
                {
                    Id = "fa",
                    Description = "Farsi"
                },
                new Language()
                {
                    Id = "de",
                    Description = "German"
                },
                new Language()
                {
                    Id = "es",
                    Description = "Spanish"
                },
                new Language()
                {
                    Id = "fr",
                    Description = "French"
                },
                new Language()
                {
                    Id = "ja",
                    Description = "Japanese"
                },
                new Language()
                {
                    Id = "it",
                    Description = "Italian"
                },
                new Language()
                {
                    Id = "cn",
                    Description = "Chinese (S)"
                },
                new Language()
                {
                    Id = "tr",
                    Description = "Turkish"
                }
            );
        }
    }
}
