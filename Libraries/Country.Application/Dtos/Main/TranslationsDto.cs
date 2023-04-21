using CNG.Abstractions.Signatures;

namespace Country.Application.Dtos.Main
{
    public class TranslationsDto:IListDto<Guid>
    {
        public Guid Id { get; set; }
        public string? LanguageDescription { get; set; }
        public string? Description { get; set; }
    }
}
