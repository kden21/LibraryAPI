using Contracts.Human.CreateHuman;
using Contracts.Human.DeleteHuman;
using Contracts.Human.GetHumanById;
using Contracts.Human.GetHumans;
using Contracts.Human.UpdateHuman;
using Handlers.CreateHuman;
using Handlers.DeleteHuman;
using Handlers.GetHumanById;
using Handlers.GetHumans;
using Handlers.UpdateHuman;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ComponentRegistrar.Registrars;

public static class HandlerRegistrar
{
    public static IServiceCollection AddHandlerService(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ApiRegistrar));
        
        services.AddTransient<IRequestHandler<GetHumansQuery, GetHumansResponse>, GetHumansHandler>();
        services.AddTransient<IRequestHandler<CreateHumanCommand, CreateHumanResponse>, CreateHumanHandler>();
        services.AddTransient<IRequestHandler<DeleteHumanCommand, DeleteHumanResponse>, DeleteHumanHandler>();
        services.AddTransient<IRequestHandler<UpdateHumanCommand, UpdateHumanResponse>, UpdateHumanHandler>();
        services.AddTransient<IRequestHandler<GetHumanByIdQuery, GetHumanByIdResponse>, GetHumanByIdHandler>();
        
        return services;
    }
}