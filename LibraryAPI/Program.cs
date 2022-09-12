using ComponentRegistrar.StartupRegistrars;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build()
    .SetupMiddleware()
    .Run();