using Newtonsoft.Json;

namespace Country.Infrastructure.Roots.Main
{
    public class CountryRoot
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
        [JsonProperty(PropertyName = "iso3")]
        public string? Iso3 { get; set; }
        [JsonProperty(PropertyName = "iso2")]
        public string? Iso2 { get; set; }
        [JsonProperty(PropertyName = "numeric_code")]
        public string? NumericCode { get; set; }
        [JsonProperty(PropertyName = "phone_code")]
        public string? PhoneCode { get; set; }
        [JsonProperty(PropertyName = "capital")]
        public string? Capital { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public string? Currency { get; set; }
        [JsonProperty(PropertyName = "currency_name")]
        public string? CurrencyName { get; set; }
        [JsonProperty(PropertyName = "currency_symbol")]
        public string? CurrencySymbol { get; set; }
        [JsonProperty(PropertyName = "tld")]
        public string? Tld { get; set; }
        [JsonProperty(PropertyName = "native")]
        public string? Native { get; set; }
        [JsonProperty(PropertyName = "region")]
        public string? Region { get; set; }
        [JsonProperty(PropertyName = "subregion")]
        public string? SubRegion { get; set; }
        [JsonProperty(PropertyName = "timezones")]
        public Timezone[]? Timezones { get; set; }
        [JsonProperty(PropertyName = "translations")]
        public Translations? Translation { get; set; }
        [JsonProperty(PropertyName = "latitude")]
        public string? Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public string? Longitude { get; set; }
        [JsonProperty(PropertyName = "emoji")]
        public string? Emoji { get; set; }
        [JsonProperty(PropertyName = "emojiU")]
        public string? EmojiU { get; set; }
        public class Translations
        {
            [JsonProperty(PropertyName = "kr")]
            public string? Kr { get; set; }
            [JsonProperty(PropertyName = "pt-BR")]
            public string? PtBr { get; set; }
            [JsonProperty(PropertyName = "pt")]
            public string? Pt { get; set; }
            [JsonProperty(PropertyName = "nl")]
            public string? Nl { get; set; }
            [JsonProperty(PropertyName = "hr")]
            public string? Hr { get; set; }
            [JsonProperty(PropertyName = "fa")]
            public string? Fa { get; set; }
            [JsonProperty(PropertyName = "de")]
            public string? De { get; set; }
            [JsonProperty(PropertyName = "es")]
            public string? Es { get; set; }
            [JsonProperty(PropertyName = "fr")]
            public string? Fr { get; set; }
            [JsonProperty(PropertyName = "ja")]
            public string? Ja { get; set; }
            [JsonProperty(PropertyName = "it")]
            public string? It { get; set; }
            [JsonProperty(PropertyName = "cn")]
            public string? Cn { get; set; }
            [JsonProperty(PropertyName = "tr")]
            public string? Tr { get; set; }
        }

        public class Timezone
        {
            [JsonProperty(PropertyName = "zoneName")]
            public string? ZoneName { get; set; }
            [JsonProperty(PropertyName = "gmtOffset")]
            public int GmtOffset { get; set; }
            [JsonProperty(PropertyName = "gmtOffsetName")]
            public string? GmtOffsetName { get; set; }
            [JsonProperty(PropertyName = "abbreviation")]
            public string? Abbreviation { get; set; }
            [JsonProperty(PropertyName = "tzName")]
            public string? TzName { get; set; }
        }
    }

}
