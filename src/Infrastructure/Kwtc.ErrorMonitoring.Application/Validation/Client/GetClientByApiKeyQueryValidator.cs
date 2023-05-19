namespace Kwtc.ErrorMonitoring.Application.Validation.Client;

using Clients.Queries;
using FluentValidation;

public class GetClientByApiKeyQueryValidator : AbstractValidator<GetClientByApiKeyQuery>
{
    public GetClientByApiKeyQueryValidator()
    {
        this.RuleFor(x => x.ApiKey)
            .NotEmpty()
            .WithMessage("The api key must be provided.");
    }
}
