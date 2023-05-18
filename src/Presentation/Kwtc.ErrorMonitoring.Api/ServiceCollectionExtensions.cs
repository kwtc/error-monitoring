namespace Kwtc.ErrorMonitoring.Api;

using Attributes;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services
            .AddMediatR(config =>
                config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        services.AddScoped(typeof(AuthorizationFilter));

        return services;
    }
}
