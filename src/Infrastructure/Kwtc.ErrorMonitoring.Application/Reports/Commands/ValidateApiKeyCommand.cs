namespace Kwtc.ErrorMonitoring.Application.Reports.Commands;

using Domain.Client;
using MediatR;
using Persistence.Client;

public record ValidateApiKeyCommand(Guid ApiKey) : IRequest<Client?>;

/// <summary>
/// Gets a registered client based on a given api key or null if the api key is invalid.
/// </summary>
internal sealed class ValidateApiKeyCommandHandler : IRequestHandler<ValidateApiKeyCommand, Client?>
{
    private readonly IClientRepository clientRepository;

    public ValidateApiKeyCommandHandler(IClientRepository clientRepository)
    {
        this.clientRepository = clientRepository;
    }

    public async Task<Client?> Handle(ValidateApiKeyCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implement actual validation logic

        // Get client created by seed data while testing
        return await this.clientRepository.GetAClientAsync(cancellationToken)
               ?? throw new InvalidOperationException("No client found");
    }
}
