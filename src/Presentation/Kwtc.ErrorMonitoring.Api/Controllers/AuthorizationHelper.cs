namespace Kwtc.ErrorMonitoring.Api.Controllers;

using System.Net;
using Application.Exceptions;
using Domain.Client;

public static class AuthorizationHelper
{
    public const string AuthorizedClient = "AuthorizedClient";
    
    public static Client GetClient(HttpRequest request)
    {
        if (!request.HttpContext.Items.TryGetValue(AuthorizedClient, out var item)
            || item is not Client client)
        {
            throw new HttpResponseException((int)HttpStatusCode.Unauthorized);
        }

        return client;
    }
}
