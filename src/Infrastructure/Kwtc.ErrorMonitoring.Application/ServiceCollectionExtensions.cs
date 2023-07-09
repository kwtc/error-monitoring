using FluentValidation;
using Kwtc.ErrorMonitoring.Application.Abstractions.Mapping;
using Kwtc.ErrorMonitoring.Application.Configuration;
using Kwtc.ErrorMonitoring.Application.Events.Commands;
using Kwtc.ErrorMonitoring.Application.Mappers;
using Kwtc.ErrorMonitoring.Application.Models.Payload;
using Kwtc.ErrorMonitoring.Application.Validation.Payload;
using Kwtc.ErrorMonitoring.Domain.Event;
using Microsoft.Extensions.DependencyInjection;
using Exception = Kwtc.ErrorMonitoring.Domain.Event.Exception;

namespace Kwtc.ErrorMonitoring.Application;

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
