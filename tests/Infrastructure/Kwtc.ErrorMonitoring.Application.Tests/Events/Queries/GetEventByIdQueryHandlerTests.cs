using Kwtc.ErrorMonitoring.Application.Events.Queries;
using Kwtc.ErrorMonitoring.Persistence.Event;

namespace Kwtc.ErrorMonitoring.Application.Tests.Events.Queries;

public class GetEventByIdQueryHandlerTests
{
    private readonly Mock<IEventRepository> eventRepositoryMock = new();

    [Fact]
    public async Task Handler_WhenEventDoesNotExist_ReturnsNull()
    {
        // TODO: Implement test using in memory database
        
        // Arrange
        var sut = this.GetSut();
        var query = new GetEventByIdQuery(Guid.NewGuid());

        // Act
        var result = await sut.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }

    private GetEventByIdQueryHandler GetSut()
    {
        return new GetEventByIdQueryHandler(this.eventRepositoryMock.Object);
    }
}
