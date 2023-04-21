using CNG.Abstractions.Signatures;

namespace Country.Domain.Entities.EF.Main
{
    public class Language : IEntity<string>
    {
        public string Id { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<Translation>? Translations { get; set; }
    }
}
