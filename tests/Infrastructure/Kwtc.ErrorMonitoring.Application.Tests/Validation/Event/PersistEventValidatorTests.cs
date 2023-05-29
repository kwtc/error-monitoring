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
            ExceptionType = TestHelper.StringWithLengthOf511,
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
            ExceptionType = TestHelper.StringWithLengthOf511,
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

    [Fact]
    public async Task Validator_WhenExceptionTypeIsTooLong_ShouldThrow()
    {
        // Arrange
        var @event = new Event
        {
            ClientId = Guid.NewGuid(),
            ApplicationId = Guid.NewGuid(),
            ExceptionType = TestHelper.StringWithLengthOf513,
            Severity = Severity.Error,
            Exceptions = new List<Exception> { new() }
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(@event);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(4)]
    public async Task Validator_WhenSeverityNotInEnum_ShouldThrow(int severity)
    {
        // Arrange
        var @event = new Event
        {
            ClientId = Guid.NewGuid(),
            ApplicationId = Guid.NewGuid(),
            ExceptionType = TestHelper.StringWithLengthOf511,
            Severity = (Severity)severity,
            Exceptions = new List<Exception> { new() }
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(@event);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Validator_WhenExceptionsIsEmpty_ShouldThrow()
    {
        // Arrange
        var @event = new Event
        {
            ClientId = Guid.NewGuid(),
            ApplicationId = Guid.NewGuid(),
            ExceptionType = TestHelper.StringWithLengthOf511,
            Severity = Severity.Error,
            Exceptions = new List<Exception>()
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(@event);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Validator_WhenExceptionsIsDefault_ShouldThrow()
    {
        // Arrange
        var @event = new Event
        {
            ClientId = Guid.NewGuid(),
            ApplicationId = Guid.NewGuid(),
            ExceptionType = TestHelper.StringWithLengthOf511,
            Severity = Severity.Error
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(@event);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task Validator_WhenEventIsValid_ShouldNotThrow(int severity)
    {
        // Arrange
        var @event = new Event
        {
            ClientId = Guid.NewGuid(),
            ApplicationId = Guid.NewGuid(),
            ExceptionType = TestHelper.StringWithLengthOf511,
            Severity = (Severity)severity,
            Exceptions = new List<Exception> { new() }
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(@event);

        // Assert
        await act.Should().NotThrowAsync<ValidationException>();
    }

    private static PersistEventValidator GetSut()
    {
        return new PersistEventValidator();
    }
}
