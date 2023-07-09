using Kwtc.ErrorMonitoring.Api.Attributes;

namespace Kwtc.ErrorMonitoring.Api;

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
