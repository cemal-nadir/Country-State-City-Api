using Country.Application.Services.Main;
using Microsoft.AspNetCore.Mvc;

namespace Country.API.Extensions
{
    public static class RouteExtensions
    {
        public static void ConfigureRoutes(this IEndpointRouteBuilder builder,ICountryService countryService, IStateService stateService,ICityService cityService)
        {
           builder.CountryRoot(countryService);
           builder.StateRoot(stateService);
           builder.CityRoot(cityService);
        }

        private static void CountryRoot(this IEndpointRouteBuilder builder,ICountryService service)
        {
            builder.MapGet("/countries", async () => await service.GetAllAsync());
            builder.MapGet("/countries/{id}", async ([FromRoute]int id) => await service.GetDetailAsync(id));
            builder.MapGet("/countries/selectlist", async () => await service.CountrySelectList());

        }
        private static void StateRoot(this IEndpointRouteBuilder builder, IStateService service)
        {
            builder.MapGet("/states", async () => await service.GetAllAsync());
            builder.MapGet("/states/{id}", async ([FromRoute] int id) => await service.GetAsync(id));
            builder.MapGet("/countries/{countryId}/states/selectlist", async ([FromRoute] int countryId) => await service.StateSelectList(countryId));
        }
        private static void CityRoot(this IEndpointRouteBuilder builder, ICityService service)
        {
            builder.MapGet("/cities", async () => await service.GetAllAsync());
            builder.MapGet("/cities/{id}", async ([FromRoute] int id) => await service.GetAsync(id));
            builder.MapGet("/states/{stateId}/cities/selectlist", async ([FromRoute] int stateId) => await service.CitySelectList(stateId));
        }
    }
}
