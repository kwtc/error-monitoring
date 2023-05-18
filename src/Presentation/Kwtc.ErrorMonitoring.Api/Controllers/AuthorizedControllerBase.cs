namespace Kwtc.ErrorMonitoring.Api.Controllers;

using System.Net;
using Application.Exceptions;
using Domain.Client;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Relevant base class for controllers that contain endpoints that require authorization.
/// </summary>
public class AuthorizedControllerBase : ControllerBase
{
    public Client GetAuthorizedClient()
    {
        if (!this.Request.HttpContext.Items.TryGetValue(ItemKeys.AuthorizedClient, out var item)
            || item is not Client client)
        {
            throw new HttpResponseException((int)HttpStatusCode.Unauthorized);
        }

        return client;
    }
}
