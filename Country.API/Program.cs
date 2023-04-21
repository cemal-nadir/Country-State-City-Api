using CNG.Core.Exceptions;
using Country.API.Extensions;
using Country.Application.Services.Main;
using Country.Persistence.Services.Main;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallAllServices();

var app = builder.Build();
app.UseAllConfigurations();

var mainService = app.Services.GetService<IMainService>() ?? throw new Exception();

if (!await mainService.DatabaseIsReady())
{
    await mainService.DownloadCountries();
    await mainService.DownloadStates();
    await mainService.DownloadCities();
}

app.ConfigureRoutes(
    app.Services.GetService<ICountryService>() ?? throw new NotFoundException($"{nameof(CountryService)} not found"),
    app.Services.GetService<IStateService>() ?? throw new NotFoundException($"{nameof(StateService)} not found"),
    app.Services.GetService<ICityService>() ?? throw new NotFoundException($"{nameof(CityService)} not found"));

app.Run();