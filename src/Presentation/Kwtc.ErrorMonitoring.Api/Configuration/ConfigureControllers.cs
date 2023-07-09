using Kwtc.ErrorMonitoring.Api.Filters;

namespace Kwtc.ErrorMonitoring.Api.Configuration;

internal static class ConfigureControllers
{
    public static IServiceCollection AddConfiguredControllers(this IServiceCollection services)
    {
        services.AddControllers(options => { options.Filters.Add<HttpResponseExceptionFilter>(); });

        return services;
    }
}
