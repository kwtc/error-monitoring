namespace Kwtc.ErrorMonitoring.WebApi.Groups.Report;

using Application.Reports.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public static class ReportGroup
{
    public static RouteGroupBuilder MapReportGroup(this RouteGroupBuilder builder)
    {
        builder
            .MapPost("/notify",
                async ([FromServices] IMediator mediator, Guid clientId, Guid? appId, CancellationToken cancellationToken) =>
                {
                    // var payload = await this.GetBodyAsStringAsync(cancellationToken);
                    // var client = this.GetAuthorizedClient();
                    // var report = await mediator.Send(new MapReportPayloadJsonCommand(payload, client.Id), cancellationToken);
                    // await mediator.Send(new PersistReportCommand(report), cancellationToken);
                });

        return builder;
    }
}
