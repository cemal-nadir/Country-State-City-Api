using Newtonsoft.Json;

namespace Country.Infrastructure.Roots.Main
{
    public class CityRoot
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
        [JsonProperty(PropertyName = "state_id")]
        public int StateId { get; set; }
        [JsonProperty(PropertyName = "state_code")]
        public string? StateCode { get; set; }
        [JsonProperty(PropertyName = "state_name")]
        public string? StateName { get; set; }
        [JsonProperty(PropertyName = "country_id")]
        public int CountryId { get; set; }
        [JsonProperty(PropertyName = "country_code")]
        public string? CountryCode { get; set; }
        [JsonProperty(PropertyName = "country_name")]
        public string? CountryName { get; set; }
        [JsonProperty(PropertyName = "latitude")]
        public string? Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public string? Longitude { get; set; }
        [JsonProperty(PropertyName = "wikiDataId")]
        public string? WikiDataId { get; set; }

    }
}
