namespace Kwtc.ErrorMonitoring.WebApi.Filters;

using Application.Clients.Queries;
using MediatR;

public class AuthenticationFilter : IEndpointFilter
{
    private readonly IMediator mediator;

    public AuthenticationFilter(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(Constants.HeaderApiKey, out var apiKeyValue) ||
            !Guid.TryParse(apiKeyValue, out var apiKey))
        {
            // context.HttpContext.Result = new UnauthorizedObjectResult(string.Empty);
            return Task.CompletedTask;
        }

        var client = await this.mediator.Send(new GetClientByApiKeyQuery(apiKey));
        if (client == null)
        {
            // context.Result = new UnauthorizedObjectResult(string.Empty);
            return Task.CompletedTask;
        }

        context.HttpContext.Items.Add(Constants.AuthorizedClient, client);

        return await next(context);
    }
}
