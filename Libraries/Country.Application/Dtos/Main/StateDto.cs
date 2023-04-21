using CNG.Abstractions.Signatures;

namespace Country.Application.Dtos.Main
{
    public class StateDto:IDto
    {
        public int CountryId { get; set; }
        public string? Name { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public string? StateCode { get; set; }
        public string? Type { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }
}
