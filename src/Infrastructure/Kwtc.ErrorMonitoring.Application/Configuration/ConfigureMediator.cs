namespace Kwtc.ErrorMonitoring.Application.Configuration;

using Clients.Queries;
using Domain.Client;
using Domain.Report;
using Event.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Models.Report.Payload;
using Models.Report.Response;
using Report.Commands;
using Report.Queries;

internal static class ConfigureMediator
{
    public static IServiceCollection AddConfiguredMediator(this IServiceCollection services)
    {
        services
            .AddMediatR(config =>
                config
                    .RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
                    .AddBehavior<IPipelineBehavior<CreateReportCommand, ReportPayload>, ValidationBehaviour<CreateReportCommand, ReportPayload>>()
                    .AddBehavior<IPipelineBehavior<GetEventByReportIdQuery, Event?>, ValidationBehaviour<GetEventByReportIdQuery, Event?>>()
                    .AddBehavior<IPipelineBehavior<GetClientByApiKeyQuery, Client?>, ValidationBehaviour<GetClientByApiKeyQuery, Client?>>()
                    .AddBehavior<IPipelineBehavior<GetReportResponseByClientIdAndAppIdQuery, ReportResponse>,
                        ValidationBehaviour<GetReportResponseByClientIdAndAppIdQuery, ReportResponse>>()
            );

        return services;
    }
}
