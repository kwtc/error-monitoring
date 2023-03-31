namespace Kwtc.ErrorMonitoring.Application.ErrorReports.Commands;

using MediatR;

public record ValidateApiKeyCommand(Guid ApiKey) : IRequest<bool>;

internal sealed class ValidateApiKeyCommandHandler : IRequestHandler<ValidateApiKeyCommand, bool>
{
    public Task<bool> Handle(ValidateApiKeyCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implement actual validation logic
        return Task.FromResult(true);
    }
}
