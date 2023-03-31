namespace Kwtc.ErrorMonitoring.Application.ErrorReports.Commands;

using System.Text.Json;
using Abstractions.Mapping;
using Domain.Report;
using Mapping;
using MediatR;
using Models.Report;
using Validators.ErrorReportPayload;

public record ValidateAndConvertErrorReportPayloadCommand(string Json) : IRequest<Report>;

internal sealed class ValidateAndConvertErrorReportPayloadCommandHandler : IRequestHandler<ValidateAndConvertErrorReportPayloadCommand, Report>
{
    private readonly IMapper<ReportPayload, Report> mapper;

    public ValidateAndConvertErrorReportPayloadCommandHandler(IMapper<ReportPayload, Report> mapper)
    {
        this.mapper = mapper;
    }

    public async Task<Report> Handle(ValidateAndConvertErrorReportPayloadCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Json))
        {
            throw new InvalidOperationException("Payload is empty.");
        }
        
        var payload = JsonSerializer.Deserialize<ReportPayload>(request.Json)
                      ?? throw new InvalidOperationException("Unable to deserialize payload.");

        await new ErrorReportPayloadValidator().ValidateAsync(payload, cancellationToken);

        return this.mapper.MapNew(payload);
    }
}
