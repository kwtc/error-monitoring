namespace Kwtc.ErrorMonitoring.Api.Configuration;

internal static class ConfigureSwagger
{
    public static IServiceCollection AddConfiguredSwagger(this IServiceCollection services)
    {
        services
            .AddSwaggerGen()
            .ConfigureOptions<SwaggerOptions>();

        return services;
    }
}
