using FluentValidation;
using Kwtc.ErrorMonitoring.Application.Validation.Event;
using Kwtc.ErrorMonitoring.Domain.Event;

namespace Kwtc.ErrorMonitoring.Application.Tests.Validation.Event;

public class PersistTraceValidatorTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Validator_WhenExceptionIdIsZero_ShouldThrow(int exceptionId)
    {
        // Arrange
        var trace = new Trace
        {
            ExceptionId = exceptionId,
            File = TestHelper.StringWithLengthOf511,
            Method = TestHelper.StringWithLengthOf511
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(trace);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public async Task Validator_WhenFileIsEmpty_ShouldThrow()
    {
        // Arrange
        var trace = new Trace
        {
            ExceptionId = 1,
            File = string.Empty,
            Method = TestHelper.StringWithLengthOf511
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(trace);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Validator_WhenFileExceedsMaxLength_ShouldThrow()
    {
        // Arrange
        var trace = new Trace
        {
            ExceptionId = 1,
            File = TestHelper.StringWithLengthOf513,
            Method = TestHelper.StringWithLengthOf511
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(trace);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Validator_WhenMethodIsEmpty_ShouldThrow()
    {
        // Arrange
        var trace = new Trace
        {
            ExceptionId = 1,
            File = TestHelper.StringWithLengthOf511,
            Method = string.Empty
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(trace);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Validator_WhenMethodExceedsMaxLength_ShouldThrow()
    {
        // Arrange
        var trace = new Trace
        {
            ExceptionId = 1,
            File = TestHelper.StringWithLengthOf511,
            Method = TestHelper.StringWithLengthOf513
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(trace);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1024)]
    [InlineData(8192)]
    public async Task Validator_WhenTraceIsValid_ShouldNotThrow(int exceptionId)
    {
        // Arrange
        var trace = new Trace
        {
            ExceptionId = exceptionId,
            File = TestHelper.StringWithLengthOf511,
            Method = TestHelper.StringWithLengthOf511
        };
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(trace);

        // Assert
        await act.Should().NotThrowAsync<ValidationException>();
    }

    private PersistTraceValidator GetSut()
    {
        return new PersistTraceValidator();
    }
}
