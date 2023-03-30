namespace Kwtc.ErrorMonitoring.Application;

using Abstractions.Mapping;
using Domain.ErrorReport;
using Mappers;
using Microsoft.Extensions.DependencyInjection;
using Models.Payload.ErrorReport;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddMediatR(config =>
                config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        services.AddScoped<IMapper<ErrorReportPayload, ErrorReport>, ErrorReportMapper>();

        return services;
    }
}
