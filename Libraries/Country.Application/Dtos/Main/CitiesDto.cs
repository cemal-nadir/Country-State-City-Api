using CNG.Abstractions.Signatures;

namespace Country.Application.Dtos.Main
{
    public class CitiesDto:IListDto<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? StateCode { get; set; }
        public string? StateName { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? WikiDataId { get; set; }
    }
}
