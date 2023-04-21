using CNG.Abstractions.Signatures;

namespace Country.Application.Dtos.Main
{
    public class CityDto:IDto
    {
        public string? Name { get; set; }
        public int StateId { get; set; }
        public string? StateCode { get; set; }
        public string? StateName { get; set; }
        public int CountryId { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? WikiDataId { get; set; }
    }
}
