namespace Kwtc.ErrorMonitoring.Application.Report.Commands;

using System.Text.Json;
using MediatR;
using Models.Report.Payload;
using Validators.Payload;

public record DeserializeReportPayloadCommand(string Payload) : IRequest<ReportPayload>;

internal sealed class DeserializeReportPayloadCommandHandler : IRequestHandler<DeserializeReportPayloadCommand, ReportPayload>
{
    public async Task<ReportPayload> Handle(DeserializeReportPayloadCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Payload))
        {
            throw new InvalidOperationException("Payload is empty.");
        }
        
        var payload = JsonSerializer.Deserialize<ReportPayload>(request.Payload)
                      ?? throw new InvalidOperationException("Unable to deserialize payload.");

        await new ReportPayloadValidator().ValidateAsync(payload, cancellationToken);
        
        return payload;
    }
} 