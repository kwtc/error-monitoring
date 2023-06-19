using Kwtc.ErrorMonitoring.Persistence.Client;
using Kwtc.ErrorMonitoring.Persistence.Event;
using Kwtc.ErrorMonitoring.Persistence.Exception;
using Kwtc.ErrorMonitoring.Persistence.Trace;
using Kwtc.Persistence.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Kwtc.ErrorMonitoring.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        return services
               .AddScoped<IConnectionFactory, MySqlConnectionFactory>()
               .AddScoped<IClientRepository, ClientRepository>()
               .AddScoped<IEventRepository, EventRepository>()
               .AddScoped<IExceptionRepository, ExceptionRepository>()
               .AddScoped<ITraceRepository, TraceRepository>();
    }
}
