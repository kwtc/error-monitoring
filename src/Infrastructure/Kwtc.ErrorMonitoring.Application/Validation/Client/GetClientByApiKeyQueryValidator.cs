using FluentValidation;
using Kwtc.ErrorMonitoring.Application.Clients.Queries;

namespace Kwtc.ErrorMonitoring.Application.Validation.Client;

public class GetClientByApiKeyQueryValidator : AbstractValidator<GetClientByApiKeyQuery>
{
    public GetClientByApiKeyQueryValidator()
    {
        this.RuleFor(x => x.ApiKey)
            .NotEmpty();
    }
}
