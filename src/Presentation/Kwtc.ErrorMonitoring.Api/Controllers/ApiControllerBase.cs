namespace Kwtc.ErrorMonitoring.Api.Controllers;

using System.Net;
using Application.Exceptions;
using Domain.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Base class for project api controllers.
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}")]
public abstract class ApiControllerBase : ControllerBase
{
    private IMediator? mediator;

    protected IMediator Mediator => mediator
        ??= HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("Mediator is not registered in the service collection.");

    protected Client GetAuthorizedClient()
    {
        if (!this.Request.HttpContext.Items.TryGetValue(Constants.AuthorizedClient, out var item)
            || item is not Client client)
        {
            throw new HttpResponseException((int)HttpStatusCode.Unauthorized);
        }

        return client;
    }

    protected async Task<string> GetBodyAsStringAsync(CancellationToken cancellationToken = default)
    {
        using var reader = new StreamReader(this.Request.Body);
        return await reader.ReadToEndAsync(cancellationToken);
    }
}
