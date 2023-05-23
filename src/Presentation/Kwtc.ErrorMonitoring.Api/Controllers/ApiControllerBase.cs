namespace Kwtc.ErrorMonitoring.Api.Controllers;

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

    /// <summary>
    /// Gets the authorized client.
    /// Requires the AuthorizationAttribute to be set on the calling controller method.
    /// </summary>
    protected Client GetAuthorizedClient()
    {
        if (!this.Request.HttpContext.Items.TryGetValue(Constants.AuthorizedClient, out var item)
            || item is not Client client)
        {
            throw new InvalidOperationException(
                "Authorized client is not found. This is likely due to the calling controller method not being decorated with the AuthorizationAttribute.");
        }

        return client;
    }

    protected async Task<string> GetBodyAsStringAsync(CancellationToken cancellationToken = default)
    {
        using var reader = new StreamReader(this.Request.Body);
        return await reader.ReadToEndAsync(cancellationToken);
    }
}
