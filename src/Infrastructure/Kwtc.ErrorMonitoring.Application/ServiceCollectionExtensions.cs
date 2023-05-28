namespace Kwtc.ErrorMonitoring.Application;

using Abstractions.Mapping;
using Configuration;
using Domain.Event;
using FluentValidation;
using Mappers;
using Microsoft.Extensions.DependencyInjection;
using Models.Report.Payload;
using Reports.Commands;
using Validation.Report;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddConfiguredMediator();

        services.AddScoped<IMapper<EventPayload, Event>, EventMapper>();
        services.AddScoped<IMapper<ExceptionPayload, Exception>, ExceptionMapper>();
        services.AddScoped<IMapper<TracePayload, Trace>, TraceMapper>();

        services.AddScoped<IValidator<MapEventPayloadJsonCommand>, MapEventPayloadJsonCommandValidator>();

        return services;
    }
}
