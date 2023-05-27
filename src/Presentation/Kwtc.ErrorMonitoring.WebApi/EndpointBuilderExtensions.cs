namespace Kwtc.ErrorMonitoring.WebApi;

using Filters;

public static class EndpointBuilderExtensions
{
    public static TBuilder RequireAuthentication<TBuilder>(this TBuilder builder) where TBuilder : IRouteHandler
    {
        builder.AddEndpointFilter<AuthenticationFilter>();

        return builder;
    }
}
