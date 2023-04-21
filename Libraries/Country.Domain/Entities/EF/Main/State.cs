using CNG.Abstractions.Signatures;

namespace Country.Domain.Entities.EF.Main
{
    public class State : IEntity<int>
    {

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string? Name { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public string? StateCode { get; set; }
        public string? Type { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public virtual Country? Country { get; set; }
        public virtual ICollection<City>? Cities { get; set; }

    }
}
