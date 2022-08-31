using AppServices.MapProfiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ComponentRegistrar.Registrars;

public static class AutoMapperRegistrar
{
    public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
    {
        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        
        return services;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile(new HumanMapProfile());
            }
        );
        configuration.AssertConfigurationIsValid();
                
        return configuration;
    }
}