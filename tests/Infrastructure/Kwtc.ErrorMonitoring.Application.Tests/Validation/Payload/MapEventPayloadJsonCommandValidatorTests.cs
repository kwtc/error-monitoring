namespace Kwtc.ErrorMonitoring.Application.Tests.Validation.Payload;

using Application.Events.Commands;
using Application.Validation.Payload;
using FluentAssertions;
using FluentValidation;

public class MapEventPayloadJsonCommandValidatorTests
{
    [Fact]
    public Task Validator_WhenJsonContentIsEmpty_ShouldThrow()
    {
        // Arrange
        var command = new MapEventPayloadJsonCommand(string.Empty);
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(command);

        // Assert
        return act.Should().ThrowAsync<ValidationException>();
    }

    private static MapEventPayloadJsonCommandValidator GetSut()
    {
        return new MapEventPayloadJsonCommandValidator();
    }
}
