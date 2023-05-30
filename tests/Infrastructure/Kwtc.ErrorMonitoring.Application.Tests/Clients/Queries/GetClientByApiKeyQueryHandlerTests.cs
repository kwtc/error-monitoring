namespace Kwtc.ErrorMonitoring.Application.Tests.Clients.Queries;

using Application.Clients.Queries;
using Moq;
using Persistence.Client;

public class GetClientByApiKeyQueryHandlerTests
{
    private readonly Mock<IClientRepository> clientRepositoryMock = new();

    [Fact]
    public async Task Handle_WhenClientIsFound_ReturnsClient()
    {
        // Arrange
        var sut = this.GetSut();
        var client = new Client(Guid.NewGuid(), "Test", "Test", "Test");
        this.clientRepositoryMock.Setup(x => x.GetClientByApiKeyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(client);

        // Act
        var result = await sut.Handle(new GetClientByApiKeyQuery(Guid.NewGuid()), CancellationToken.None);

        // Assert
        result.Should().Be(client);
    }
    
    private GetClientByApiKeyQueryHandler GetSut()
    {
        return new GetClientByApiKeyQueryHandler(clientRepositoryMock.Object);
    }
}
