namespace Kwtc.ErrorMonitoring.Application.Tests.Validation.Client;

using FluentAssertions;
using FluentValidation;
using Clients.Queries;
using Kwtc.ErrorMonitoring.Application.Validation.Client;

public class GetClientByApiKeyQueryValidatorTests
{
    [Fact]
    public async Task Validator_WhenApiKeyIsEmpty_ShouldThrow()
    {
        // Arrange
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(new GetClientByApiKeyQuery(Guid.Empty));

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public async Task Validator_WhenApiKeyIsValid_ShouldNotThrow()
    {
        // Arrange
        var sut = GetSut();

        // Act
        var act = () => sut.ValidateAndThrowAsync(new GetClientByApiKeyQuery(Guid.NewGuid()));

        // Assert
        await act.Should().NotThrowAsync<ValidationException>();
    }

    private static GetClientByApiKeyQueryValidator GetSut()
    {
        return new GetClientByApiKeyQueryValidator();
    }
}
