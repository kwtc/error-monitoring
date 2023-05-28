namespace Kwtc.ErrorMonitoring.Application.Configuration;

using Domain.Event;
using Events.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServiceCollectionExtensions = ServiceCollectionExtensions;

internal static class ConfigureMediator
{
    public static IServiceCollection AddConfiguredMediator(this IServiceCollection services)
    {
        services
            .AddMediatR(config =>
                    config
                        .RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
                        .AddBehavior<IPipelineBehavior<MapEventPayloadJsonCommand, Event>, ValidationBehavior<MapEventPayloadJsonCommand, Event>>()
                        .AddBehavior<IPipelineBehavior<PersistEventCommand, Task>, ValidationBehavior<PersistEventCommand, Task>>()
                // .AddBehavior<IPipelineBehavior<GetEventByReportIdQuery, Event?>, ValidationBehaviour<GetEventByReportIdQuery, Event?>>()
                // .AddBehavior<IPipelineBehavior<GetClientByApiKeyQuery, Client?>, ValidationBehaviour<GetClientByApiKeyQuery, Client?>>()
                // .AddBehavior<IPipelineBehavior<GetReportResponseByClientIdAndAppIdQuery, ReportResponse>,
                //     ValidationBehaviour<GetReportResponseByClientIdAndAppIdQuery, ReportResponse>>()
            );

        return services;
    }
}
