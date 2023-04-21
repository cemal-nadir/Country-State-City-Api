using CNG.Abstractions.Signatures;

namespace Country.Domain.Entities.EF.Main
{
    public class Translation : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? LanguageId { get; set; }
        public int CountryId { get; set; }
        public string? Description { get; set; }
        public virtual Language? Language { get; set; }
        public virtual Country? Country { get; set; }
    }
}
