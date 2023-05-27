namespace Kwtc.ErrorMonitoring.WebApi.Groups.Event;

using Application.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;

public static class EventGroup
{
    public static RouteGroupBuilder MapEventGroup(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetEvents)
               .RequireAuthentication();

        return builder;
    }

    private static async Task<IResult> GetEvents(IMediator mediator, Guid clientId, Guid? appId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetReportResponseByClientIdAndAppIdQuery(clientId, appId), cancellationToken);

        return TypedResults.Ok(response);
    }

    public static TBuilder RequireAuthorization<TBuilder>(this TBuilder builder)
        where TBuilder : IEndpointConventionBuilder
    {
        builder.RequireAuthorization(pb => pb.RequireAssertion(IsAuthorized));
        return builder;
    }

    private static bool IsAuthorized(AuthorizationHandlerContext context)
    {
        // Write logic here
        return true;
    }
}
