using AutoMapper;
using AutoMapper.Internal;
using Country.Application.Dtos;
using Country.Application.Mappings;

namespace Country.API.Installers.Services
{
    public class Mapper:IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, DbModel env)
        {
            services.AddSingleton(new MapperConfiguration(cfg =>
            {
                cfg.Internal().MethodMappingEnabled = false;
                cfg.AddProfile(new AllProfiles());
            }).CreateMapper());
        }
    }
}
