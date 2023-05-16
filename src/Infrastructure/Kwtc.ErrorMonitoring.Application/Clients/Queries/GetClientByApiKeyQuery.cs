namespace Kwtc.ErrorMonitoring.Application.Clients.Queries;

using Domain.Client;
using MediatR;
using Persistence.Client;

public record GetClientByApiKeyQuery(Guid ApiKey) : IRequest<Client?>;

/// <summary>
/// Gets a registered client based on a given api key or null if the api key isn't found.
/// </summary>
internal sealed class GetClientByApiKeyQueryHandler : IRequestHandler<GetClientByApiKeyQuery, Client?>
{
    private readonly IClientRepository clientRepository;

    public GetClientByApiKeyQueryHandler(IClientRepository clientRepository)
    {
        this.clientRepository = clientRepository;
    }

    public async Task<Client?> Handle(GetClientByApiKeyQuery request, CancellationToken cancellationToken)
    {
        return await this.clientRepository.GetClientByApiKeyAsync(request.ApiKey, cancellationToken);
    }
}
