namespace Kwtc.ErrorMonitoring.Application.Configuration;

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Models.Report.Payload;
using Report.Commands;

internal static class ConfigureMediator
{
    public static IServiceCollection AddConfiguredMediator(this IServiceCollection services)
    {
        services
            .AddMediatR(config =>
                config
                    .RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
                    .AddBehavior<IPipelineBehavior<DeserializeReportPayloadCommand, ReportPayload>,
                        ValidationBehaviour<DeserializeReportPayloadCommand, ReportPayload>>()
            );

        return services;
    }
}
