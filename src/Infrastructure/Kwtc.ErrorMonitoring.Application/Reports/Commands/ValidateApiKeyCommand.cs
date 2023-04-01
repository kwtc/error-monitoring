namespace Kwtc.ErrorMonitoring.Application.Reports.Commands;

using Domain.Client;
using MediatR;

public record ValidateApiKeyCommand(Guid ApiKey) : IRequest<Client?>;

/// <summary>
/// Gets a registered client based on a given api key or null if the api key is invalid.
/// </summary>
internal sealed class ValidateApiKeyCommandHandler : IRequestHandler<ValidateApiKeyCommand, Client?>
{
    public Task<Client?> Handle(ValidateApiKeyCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implement actual validation logic
        return Task.FromResult(new Client
        {
            Id = Guid.NewGuid(),
            ApiKey = request.ApiKey
        });
    }
}
