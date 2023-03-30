namespace Kwtc.ErrorMonitoring.Application.ErrorReports.Queries;

using MediatR;

public record ValidateApiKeyQuery(Guid ApiKey) : IRequest<bool>;

internal sealed class ValidateApiKeyQueryHandler : IRequestHandler<ValidateApiKeyQuery, bool>
{
    public Task<bool> Handle(ValidateApiKeyQuery request, CancellationToken cancellationToken)
    {
        // TODO: Implement actual validation logic
        return Task.FromResult(true);
    }
}
