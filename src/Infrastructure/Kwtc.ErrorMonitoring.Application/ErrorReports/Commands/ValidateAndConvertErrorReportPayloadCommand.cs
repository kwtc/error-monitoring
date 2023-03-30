namespace Kwtc.ErrorMonitoring.Application.ErrorReports.Commands;

using System.Text.Json;
using Abstractions.Mapping;
using Domain.ErrorReport;
using Mapping;
using MediatR;
using Models.Payload.ErrorReport;
using Validators.ErrorReportPayload;

public record ValidateAndConvertErrorReportPayloadCommand(string Json) : IRequest<ErrorReport>;

internal sealed class ValidateAndConvertErrorReportPayloadCommandHandler : IRequestHandler<ValidateAndConvertErrorReportPayloadCommand, ErrorReport>
{
    private readonly IMapper<ErrorReportPayload, ErrorReport> mapper;

    public ValidateAndConvertErrorReportPayloadCommandHandler(IMapper<ErrorReportPayload, ErrorReport> mapper)
    {
        this.mapper = mapper;
    }

    public async Task<ErrorReport> Handle(ValidateAndConvertErrorReportPayloadCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Json))
        {
            throw new InvalidOperationException("Payload is empty.");
        }
        
        var payload = JsonSerializer.Deserialize<ErrorReportPayload>(request.Json)
                      ?? throw new InvalidOperationException("Unable to deserialize payload.");

        await new ErrorReportPayloadValidator().ValidateAsync(payload, cancellationToken);

        return this.mapper.MapNew(payload);
    }
}
