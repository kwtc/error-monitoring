namespace Kwtc.ErrorMonitoring.Application.Tests.Validation.Event;

using Application.Events.Queries;
using Application.Validation.Event;
using FluentAssertions;
using FluentValidation;

public class GetEventByIdQueryValidatorTests
{
    [Fact]
    public async Task Validator_WhenIdIsEmpty_ShouldThrow()
    {
        // Arrange
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(new GetEventByIdQuery(Guid.Empty));

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public async Task Validator_WhenIdIsValid_ShouldNotThrow()
    {
        // Arrange
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(new GetEventByIdQuery(Guid.NewGuid()));

        // Assert
        await act.Should().NotThrowAsync<ValidationException>();
    }

    private static GetEventByIdQueryValidator GetSut()
    {
        return new GetEventByIdQueryValidator();
    }
}
