using AutoMapper;
using Country.Application.Dtos.Main;
using Country.Domain.Entities.EF.Main;

namespace Country.Application.Mappings
{
    public class AllProfiles:Profile
    {
        public AllProfiles()
        {
            CreateMap<Domain.Entities.EF.Main.Country, CountryDto>().ReverseMap();
            CreateMap<Domain.Entities.EF.Main.Country, CountriesDto>();
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<State, StatesDto>();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CitiesDto>();
            CreateMap<Timezone, TimezoneDto>().ReverseMap();
            CreateMap<Timezone, TimezonesDto>();
            CreateMap<Translation, TranslationDto>().ReverseMap();
            CreateMap<Translation, TranslationsDto>().ForMember(d => d.LanguageDescription,
                m => m.MapFrom(x => x.Language != null ? x.Language.Description : ""));
        }
    }
}
