namespace Kwtc.ErrorMonitoring.Persistence;

using Abstractions;
using Abstractions.Reports;
using Microsoft.Extensions.DependencyInjection;
using Reports;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IConnectionFactory, MySqlSharedConnectionFactory>()
            .AddScoped<IReportRepository, ReportRepository>();
    }
}
