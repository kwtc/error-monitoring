namespace Kwtc.ErrorMonitoring.Application;

using Abstractions.Mapping;
using Configuration;
using Domain.Report;
using Mappers;
using Microsoft.Extensions.DependencyInjection;
using Models.Report.Payload;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddConfiguredMediator();

        services.AddScoped<IMapper<EventPayload, Domain.Report.Event>, EventMapper>();
        services.AddScoped<IMapper<ExceptionPayload, Exception>, ExceptionMapper>();
        services.AddScoped<IMapper<TracePayload, Trace>, TraceMapper>();

        return services;
    }
}
