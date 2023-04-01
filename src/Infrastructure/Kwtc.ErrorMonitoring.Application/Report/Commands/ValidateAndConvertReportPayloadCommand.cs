namespace Kwtc.ErrorMonitoring.Application.Report.Commands;

using System.Text.Json;
using Abstractions.Mapping;
using Domain.Report;
using MediatR;
using Models.Report;
using Validators.Payload;

public record ValidateAndConvertReportPayloadCommand(string Json) : IRequest<Report>;

internal sealed class ValidateAndConvertReportPayloadCommandHandler : IRequestHandler<ValidateAndConvertReportPayloadCommand, Report>
{
    private readonly IMapper<ReportPayload, Report> mapper;

    public ValidateAndConvertReportPayloadCommandHandler(IMapper<ReportPayload, Report> mapper)
    {
        this.mapper = mapper;
    }

    public async Task<Report> Handle(ValidateAndConvertReportPayloadCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Json))
        {
            throw new InvalidOperationException("Payload is empty.");
        }
        
        var payload = JsonSerializer.Deserialize<ReportPayload>(request.Json)
                      ?? throw new InvalidOperationException("Unable to deserialize payload.");

        await new ReportPayloadValidator().ValidateAsync(payload, cancellationToken);

        return this.mapper.MapNew(payload);
    }
}
