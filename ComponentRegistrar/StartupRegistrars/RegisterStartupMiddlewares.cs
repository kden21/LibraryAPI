using ComponentRegistrar.Configurators;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace ComponentRegistrar.StartupRegistrars;

public static class RegisterStartupMiddlewares
{
    public static WebApplication SetupMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader());
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.UseExceptionHandling();

        app.MapControllers();

        return app;
    }
}