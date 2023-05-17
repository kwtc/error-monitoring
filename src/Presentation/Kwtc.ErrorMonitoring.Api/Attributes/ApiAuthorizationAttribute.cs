namespace Kwtc.ErrorMonitoring.Api.Attributes;

using Application.Clients.Queries;
using Domain.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Method)]
public sealed class ApiAuthorizationAttribute : TypeFilterAttribute
{
    public ApiAuthorizationAttribute() : base(typeof(ApiAuthorizationFilter))
    {
    }
}

public class ApiAuthorizationFilter : IAsyncAuthorizationFilter
{
    private readonly IMediator mediator;

    public ApiAuthorizationFilter(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        // if (!context.HttpContext.Request.Headers.TryGetValue("x-api-key", out var apiKey) ||
        //     !Guid.TryParse(apiKey, out var guidApiKey))
        // {
        //     context.Result = new UnauthorizedObjectResult(string.Empty);
        //     return;
        // }
        //
        // var client = await this.mediator.Send(new GetClientByApiKeyQuery(guidApiKey));
        // if (client == null)
        // {
        //     context.Result = new UnauthorizedObjectResult(string.Empty);
        //     return;
        // }

        // context.HttpContext.Items.Add("Client", new Client { Id = Guid.NewGuid(), ApiKey = Guid.NewGuid(), CreatedAt = DateTime.Now });
    }
}
