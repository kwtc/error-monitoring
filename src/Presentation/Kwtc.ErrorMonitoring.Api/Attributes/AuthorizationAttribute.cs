using Kwtc.ErrorMonitoring.Application.Clients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kwtc.ErrorMonitoring.Api.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public sealed class AuthorizationAttribute : TypeFilterAttribute
{
    public AuthorizationAttribute() : base(typeof(AuthorizationFilter))
    {
    }
}

public class AuthorizationFilter : IAsyncAuthorizationFilter
{
    private readonly IMediator mediator;

    public AuthorizationFilter(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(Constants.HeaderApiKey, out var apiKeyValue) ||
            !Guid.TryParse(apiKeyValue, out var apiKey))
        {
            context.Result = new UnauthorizedObjectResult(string.Empty);
            return;
        }

        var client = await this.mediator.Send(new GetClientByApiKeyQuery(apiKey));
        if (client == null)
        {
            context.Result = new UnauthorizedObjectResult(string.Empty);
            return;
        }

        context.HttpContext.Items.Add(Constants.AuthorizedClient, client);
    }
}
