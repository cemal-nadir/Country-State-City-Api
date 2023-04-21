

using CNG.Extensions;
using Country.API.Installers;
using Country.Application.Dtos;

namespace Country.API.Extensions;

public static class InstallerExtensions
{
    public static void InstallAllServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        services.AddConsoleLogService();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        var env = new DbModel(host: Environment.GetEnvironmentVariable(variable: "DATABASE_HOST") ?? "",
            dbName: Environment.GetEnvironmentVariable(variable: "DATABASE_NAME") ?? "",
            userName: Environment.GetEnvironmentVariable(variable: "DATABASE_USER_NAME") ?? "",
            password: Environment.GetEnvironmentVariable(variable: "DATABASE_PASSWORD") ?? "",
            port: Environment.GetEnvironmentVariable(variable: "DATABASE_PORT").ToInt());
        services.AddSingleton(env);

        var installers = typeof(IServiceInstaller).Assembly.ExportedTypes
            .Where(predicate: x => typeof(IServiceInstaller).IsAssignableFrom(c: x) && x is { IsInterface: false, IsAbstract: false })
            .OrderBy(keySelector: x => x.Name)
            .Select(selector: Activator.CreateInstance)
            .Cast<IServiceInstaller>().ToList();
        installers.ForEach(action: x => x.InstallServices(services: services, env: env));
        ServiceTool.Create(services);
    }
    public static void UseAllConfigurations(this IApplicationBuilder app)
    {
        var env = app.ApplicationServices.GetService<IWebHostEnvironment>();
        if (env != null && env.IsDevelopment())
            app.UseDeveloperExceptionPage();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors();
        app.UseStaticFiles();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        app.UseSwaggerService();
        var installers = typeof(IConfigureInstaller).Assembly.ExportedTypes
            .Where(x => typeof(IConfigureInstaller).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false })
            .OrderBy(x => x.Name)
            .Select(Activator.CreateInstance)
            .Cast<IConfigureInstaller>().ToList();

        installers.ForEach(x => x.InstallConfigures(app));
    }
}