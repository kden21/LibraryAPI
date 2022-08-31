using ComponentRegistrar.Registrars;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Register.Registrars;

namespace ComponentRegistrar.StartupRegistrars;

public static class RegisterStartupServices
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        ConfigurationManager configuration = builder.Configuration;
        IWebHostEnvironment environment = builder.Environment;

        builder.Services.AddApiServices()
            .AddDataAccessServices(configuration, environment)
            .AddAutoMapperService()
            .AddAppServices()
            .AddHandlerService();

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.MaxRequestBodySize = 100_000_000;
            serverOptions.Limits.MaxRequestLineSize = 100_000_000;
            serverOptions.Limits.MaxRequestBufferSize = 100_000_000;
        });
        
        return builder;
    }
}