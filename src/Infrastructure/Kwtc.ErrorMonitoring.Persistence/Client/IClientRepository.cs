namespace Kwtc.ErrorMonitoring.Persistence.Client;

public interface IClientRepository
{
    Task<Domain.Client.Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<Domain.Client.Client?> GetClientByApiKeyAsync(Guid apiKey, CancellationToken cancellationToken = default);
    
    // TODO: Remove after testing :P
    Task<Domain.Client.Client?> GetClientAsync(CancellationToken cancellationToken = default);
}
