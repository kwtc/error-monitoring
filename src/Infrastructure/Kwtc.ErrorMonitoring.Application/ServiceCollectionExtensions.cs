namespace Kwtc.ErrorMonitoring.Application;

using Abstractions.Mapping;
using Configuration;
using Domain.Report;
using FluentValidation;
using Mappers;
using Microsoft.Extensions.DependencyInjection;
using Models.Report.Payload;
using Report.Commands;
using Validation.Report;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddConfiguredMediator();

        services.AddScoped<IMapper<ReportPayload, Domain.Report.Report>, ReportMapper>();
        services.AddScoped<IMapper<EventPayload, Domain.Report.Event>, EventMapper>();
        services.AddScoped<IMapper<ExceptionPayload, Exception>, ExceptionMapper>();
        services.AddScoped<IMapper<TracePayload, Trace>, TraceMapper>();

        services.AddScoped<IValidator<MapReportPayloadCommand>, MapReportPayloadCommandValidator>();
        services.AddScoped<IValidator<PersistReportCommand>, PersistReportCommandValidator>();

        return services;
    }
}
