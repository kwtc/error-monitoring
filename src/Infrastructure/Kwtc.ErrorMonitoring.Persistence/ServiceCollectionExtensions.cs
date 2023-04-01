namespace Kwtc.ErrorMonitoring.Persistence;

using Application.Abstractions.Database;
using Client;
using Event;
using Exception;
using Microsoft.Extensions.DependencyInjection;
using Report;
using Trace;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        return services
               .AddScoped<IConnectionFactory, MySqlSharedConnectionFactory>()
               .AddScoped<IReportRepository, ReportRepository>()
               .AddScoped<IClientRepository, ClientRepository>()
               .AddScoped<IEventRepository, EventRepository>()
               .AddScoped<IExceptionRepository, ExceptionRepository>()
               .AddScoped<ITraceRepository, TraceRepository>();
    }
}
