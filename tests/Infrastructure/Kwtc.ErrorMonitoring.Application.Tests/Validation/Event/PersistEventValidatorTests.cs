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
            ExceptionType = StringWithLengthOf511,
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
            ExceptionType = StringWithLengthOf511,
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
            ExceptionType = StringWithLengthOf513,
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
            ExceptionType = StringWithLengthOf511,
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
            ExceptionType = StringWithLengthOf511,
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
            ExceptionType = StringWithLengthOf511,
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
            ExceptionType = StringWithLengthOf511,
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

    private const string StringWithLengthOf511 =
        "xyx7qfBnc0gqo3L8SVxjqIdME6azpfnS86As3GBoVyIArYNtLsrloAoK28Iq3L356bVFyDgu3sGzpy6AXezCk7rZC0XUyAuMluIJRcuq02XVlCHyuDnSFz3F2O1dbP19CLkbIpJQpSs6sDnWAQVBvUMjUlYiGDUtDPvTKXcSVGmeoW6fkvjHXdNR7KgkJzw7PkClGDiJms2okeVyMHUg8dbCk4IgFaNKuLlpltVPHgkNHA7HI37hr4gadC6DyyYs1CkKGHdUW21plNZxpBynt9RwiI59Bwt9UhPoCFRCJQixC42vcYVeLsWgFiXteWjfLjuDBxlT2VOQWH2JddgYRLLNTDSHhfmSvcQu6FjTibMqSh7egofxhokPDkSCDKEPI9QMFg17CrtDpVWuBsRSXz3bZrWNm7DvLOlQ590dtfYSKLZZX1NFjaur1GwSnuxFVwr53tvghjM7SwIpbvAhNHTLvaFmIJOx0Ir6ukRewZ0clAtJ86WeABl1sgTQb4i";

    private const string StringWithLengthOf513 =
        "xyx7qfBnc0gqo3L8SVxjqIdME6azpfnS86As3GBoVyIArYNtLsrloAoK28Iq3L356bVFyDgu3sGzpy6AXezCk7rZC0XUyAuMluIJRcuq02XVlCHyuDnSFz3F2O1dbP19CLkbIpJQpSs6sDnWAQVBvUMjUlYiGDUtDPvTKXcSVGmeoW6fkvjHXdNR7KgkJzw7PkClGDiJms2okeVyMHUg8dbCk4IgFaNKuLlpltVPHgkNHA7HI37hr4gadC6DyyYs1CkKGHdUW21plNZxpBynt9RwiI59Bwt9UhPoCFRCJQixC42vcYVeLsWgFiXteWjfLjuDBxlT2VOQWH2JddgYRLLNTDSHhfmSvcQu6FjTibMqSh7egofxhokPDkSCDKEPI9QMFg17CrtDpVWuBsRSXz3bZrWNm7DvLOlQ590dtfYSKLZZX1NFjaur1GwSnuxFVwr53tvghjM7SwIpbvAhNHTLvaFmIJOx0Ir6ukRewZ0clAtJ86WeABl1sgTQb4ivb";
}
