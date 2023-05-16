namespace Kwtc.ErrorMonitoring.Persistence.Client;

using Domain.Client;

public interface IClientRepository
{
    Task<Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<Client?> GetClientByApiKeyAsync(Guid apiKey, CancellationToken cancellationToken = default);
    
    // TODO: Remove after testing :P
    Task<Client?> GetClientAsync(CancellationToken cancellationToken = default);
}
