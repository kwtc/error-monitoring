namespace Kwtc.ErrorMonitoring.Persistence.Client;

using Domain.Client;

public interface IClientRepository
{
    Task<Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<Client?> GetClientByApiKeyAsync(string apiKey, CancellationToken cancellationToken = default);
    
    // TODO: Remove after testing :P
    Task<Client?> GetAClientAsync(CancellationToken cancellationToken = default);
}
