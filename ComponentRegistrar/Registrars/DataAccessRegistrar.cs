using DataAccess;
using DataAccess.Repositories;
using DataAccess.Repositories.Human;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ComponentRegistrar.Registrars;

public static class DataAccessRegistrar
{
    private const string ConnectionStringsLocal = "ConnectionStringsLocal";
    private const string ConnectionStringsDocker = "ConnectionStringsDocker";

    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment )
    {
        var connectionStringFieldName = environment.IsDevelopment()
            ? ConnectionStringsLocal
            : ConnectionStringsDocker;
        
        var connectionString = configuration.GetConnectionString(connectionStringFieldName);
        
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException(
                $"Не найдена строка подключения с именем '{connectionStringFieldName}'");
            
        services.AddDbContextPool<LibraryApiDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseLazyLoadingProxies();
        });

        services.AddScoped<DbContext>(sp => sp.GetRequiredService<LibraryApiDbContext>());
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
        services.AddScoped<IHumanRepository, HumanRepository>();

        return services;
    }
}