using Country.Application.Dtos;
using Country.Application.Repositories.EF.Main;
using Country.Application.Services.Main;
using Country.Persistence.Repositories.EF.Main;
using Country.Persistence.Services.Main;

namespace Country.API.Installers.Services
{
    public class Persistence:IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, DbModel env)
        {
            MongoRepositories(services);
            EfRepositories(services);
            Services(services);
        }

        private static void EfRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICountryRepository, CountryRepository>();
            serviceCollection.AddScoped<ITimezoneRepository, TimezoneRepository>();
            serviceCollection.AddScoped<ITranslationRepository, TranslationRepository>();
            serviceCollection.AddScoped<IStateRepository, StateRepository>();
            serviceCollection.AddScoped<ICityRepository, CityRepository>();
        }
        // ReSharper disable once UnusedParameter.Local
        private static void MongoRepositories(IServiceCollection serviceCollection)
        {

        }
        private static void Services(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMainService, MainService>();
            serviceCollection.AddScoped<ICountryService, CountryService>();
            serviceCollection.AddScoped<IStateService, StateService>();
            serviceCollection.AddScoped<ICityService, CityService>();
        }
    }
}
