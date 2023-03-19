namespace Kwtc.ErrorMonitoring.Application;

using Abstractions.Mapping;
using Domain.Models.ErrorReport;
using Mappers;
using Microsoft.Extensions.DependencyInjection;
using Models;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddMediatR(config =>
                config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        services.AddScoped<IMapper<ReportPayload, ErrorReport>, ErrorReportMapper>();

        return services;
    }
}
