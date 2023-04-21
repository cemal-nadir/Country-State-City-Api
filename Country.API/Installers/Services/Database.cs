using CNG.EntityFrameworkCore.Enums;
using CNG.EntityFrameworkCore.Extensions;
using CNG.EntityFrameworkCore.Models;
using Country.Application.Dtos;
using Country.Persistence.Contexts;

namespace Country.API.Installers.Services
{
    public class Database:IServiceInstaller,IConfigureInstaller
    {
        public void InstallServices(IServiceCollection services, DbModel env)
        {
            services.AddDatabaseService<MainContext>(new DatabaseOption(DatabaseType.PostgreSql, env.Host, env.DbName, env.UserName, env.Password, env.Port));
        }

        public void InstallConfigures(IApplicationBuilder app)
        {
            app.DbMigrate<MainContext>();
        }
    }
}
