using FluentValidation;
using Kwtc.ErrorMonitoring.Application.Validation.Event;
using Exception = Kwtc.ErrorMonitoring.Domain.Event.Exception;

namespace Kwtc.ErrorMonitoring.Application.Tests.Validation.Event;

public class PersistExceptionValidatorTests
{
    [Fact]
    public Task Validator_WhenEventIdIsEmpty_ShouldThrow()
    {
        // Arrange
        var exception = new Exception
        {
            EventId = Guid.Empty,
            Message = TestHelper.StringWithLengthOf511,
            Type = TestHelper.StringWithLengthOf511
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(exception);

        // Assert
        return act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public Task Validator_WhenMessageIsEmpty_ShouldThrow()
    {
        // Arrange
        var exception = new Exception
        {
            EventId = Guid.NewGuid(),
            Message = string.Empty,
            Type = TestHelper.StringWithLengthOf511
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(exception);

        // Assert
        return act.Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public Task Validator_WhenTypeIsEmpty_ShouldThrow()
    {
        // Arrange
        var exception = new Exception
        {
            EventId = Guid.NewGuid(),
            Message = TestHelper.StringWithLengthOf511,
            Type = string.Empty
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(exception);

        // Assert
        return act.Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public Task Validator_WhenTypeExceedsMaxLength_ShouldThrow()
    {
        // Arrange
        var exception = new Exception
        {
            EventId = Guid.NewGuid(),
            Message = TestHelper.StringWithLengthOf511,
            Type = TestHelper.StringWithLengthOf513
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(exception);

        // Assert
        return act.Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public async Task Validator_WhenExceptionIsValid_ShouldNotThrow()
    {
        // Arrange
        var exception = new Exception
        {
            EventId = Guid.NewGuid(),
            Message = TestHelper.StringWithLengthOf511,
            Type = TestHelper.StringWithLengthOf511
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(exception);

        // Assert
        await act.Should().NotThrowAsync<ValidationException>();
    }

    private static PersistExceptionValidator GetSut()
    {
        return new PersistExceptionValidator();
    }
}
