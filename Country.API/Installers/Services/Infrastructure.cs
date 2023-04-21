using CNG.Http.Extensions;
using Country.Application.Dtos;
using Country.Infrastructure.Services.Main;

namespace Country.API.Installers.Services
{
    public class Infrastructure:IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, DbModel env)
        {
            services.AddHttpClientService();
            services.AddScoped<IPullService, PullService>();
        }
    }
}
