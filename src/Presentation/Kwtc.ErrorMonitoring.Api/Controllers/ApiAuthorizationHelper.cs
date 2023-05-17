namespace Kwtc.ErrorMonitoring.Api.Controllers;

using System.Net;
using Domain.Client;

public static class ApiAuthorizationHelper
{
    public static Client? GetClient(HttpRequest request)
    {
        if (request.HttpContext.Items.TryGetValue("Client", out var client))
        {
            return client as Client;
        }
        
        request.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        request.HttpContext.Response.
        return null;
    }
}
