namespace Kwtc.ErrorMonitoring.Api.Attributes;

using Application.Clients.Queries;
using Domain.Client;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;

public sealed class ApiAuthorizationAttribute : Attribute, IAuthorizationFilter
{
    private readonly IMediator mediator;
    public Client Client { get; }

    public ApiAuthorizationAttribute(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("x-api-key", out var apiKey) ||
            !Guid.TryParse(apiKey, out var guidApiKey))
        {
            context.Result = BadRequest;
            await context.Result.ExecuteResultAsync();
        }
        
        var client = await this.mediator.Send(new GetClientByApiKeyQuery(guidApiKey));
        if (client == null)
        {
            return this.Unauthorized();
        }
        
        this.Client = await this.clientRepository.GetClientByApiKeyAsync(Guid.Parse(context.HttpContext.Request.Headers["x-api-key"]), context.HttpContext.RequestAborted);
    }
}
