using Country.Application.Dtos;

namespace Country.API.Installers
{
    public interface IServiceInstaller
    {
        /// <summary>
        ///     Install Service Collection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="env"></param>
        void InstallServices(IServiceCollection services, DbModel env);
    }
}
