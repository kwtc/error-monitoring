namespace Kwtc.ErrorMonitoring.Application.Tests.Validation.Event;

using Application.Validation.Event;
using Domain.Event;
using FluentAssertions;
using FluentValidation;
using Severity = Domain.Event.Severity;

public class PersistEventValidatorTests
{
    [Fact]
    public async Task Validator_WhenClientIdIsEmpty_ShouldThrow()
    {
        // Arrange
        var @event = new Event
        {
            ClientId = Guid.Empty,
            ApplicationId = Guid.NewGuid(),
            ExceptionType = "Valid type",
            Severity = Severity.Error,
            Exceptions = new List<Exception> { new() }
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(@event);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public async Task Validator_WhenApplicationIdIsEmpty_ShouldThrow()
    {
        // Arrange
        var @event = new Event
        {
            ClientId = Guid.NewGuid(),
            ApplicationId = Guid.Empty,
            ExceptionType = "Valid type",
            Severity = Severity.Error,
            Exceptions = new List<Exception> { new() }
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(@event);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public async Task Validator_WhenExceptionTypeIsEmpty_ShouldThrow()
    {
        // Arrange
        var @event = new Event
        {
            ClientId = Guid.NewGuid(),
            ApplicationId = Guid.NewGuid(),
            ExceptionType = string.Empty,
            Severity = Severity.Error,
            Exceptions = new List<Exception> { new() }
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(@event);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    private static PersistEventValidator GetSut()
    {
        return new PersistEventValidator();
    }
}
