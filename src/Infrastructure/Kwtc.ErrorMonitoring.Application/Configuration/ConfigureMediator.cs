namespace Kwtc.ErrorMonitoring.Application.Configuration;

using Domain.Report;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Report.Commands;
using ServiceCollectionExtensions = ServiceCollectionExtensions;

internal static class ConfigureMediator
{
    public static IServiceCollection AddConfiguredMediator(this IServiceCollection services)
    {
        services
            .AddMediatR(config =>
                    config
                        .RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
                        .AddBehavior<IPipelineBehavior<CreateReportCommand, Report>, ValidationBehavior<CreateReportCommand, Report>>()
                        .AddBehavior<IPipelineBehavior<PersistReportCommand, Task>, ValidationBehavior<PersistReportCommand, Task>>()
                // .AddBehavior<IPipelineBehavior<GetEventByReportIdQuery, Event?>, ValidationBehaviour<GetEventByReportIdQuery, Event?>>()
                // .AddBehavior<IPipelineBehavior<GetClientByApiKeyQuery, Client?>, ValidationBehaviour<GetClientByApiKeyQuery, Client?>>()
                // .AddBehavior<IPipelineBehavior<GetReportResponseByClientIdAndAppIdQuery, ReportResponse>,
                //     ValidationBehaviour<GetReportResponseByClientIdAndAppIdQuery, ReportResponse>>()
            );

        return services;
    }
}
