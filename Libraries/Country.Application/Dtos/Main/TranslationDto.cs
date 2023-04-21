using CNG.Abstractions.Signatures;

namespace Country.Application.Dtos.Main
{
    public class TranslationDto:IDto
    {
        public string? LanguageId { get; set; }
        public int CountryId { get; set; }
        public string? Description { get; set; }
    }
}
