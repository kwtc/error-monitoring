namespace Kwtc.ErrorMonitoring.Application.Report.Commands;

using System.Text.Json;
using MediatR;
using Models.Report.Payload;

public record DeserializeReportPayloadCommand(string Json) : IRequest<ReportPayload>;

internal sealed class DeserializeReportPayloadCommandHandler : IRequestHandler<DeserializeReportPayloadCommand, ReportPayload>
{
    public Task<ReportPayload> Handle(DeserializeReportPayloadCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Json))
        {
            throw new InvalidOperationException("Payload is empty.");
        }

        var payload = JsonSerializer.Deserialize<ReportPayload>(request.Json)
                      ?? throw new InvalidOperationException("Unable to deserialize payload.");

        return Task.FromResult(payload);
    }
}
