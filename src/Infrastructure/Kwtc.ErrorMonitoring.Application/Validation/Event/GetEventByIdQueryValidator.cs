namespace Kwtc.ErrorMonitoring.Application.Validation.Event;

using Events.Queries;
using FluentValidation;

public class GetEventByIdQueryValidator : AbstractValidator<GetEventByIdQuery>
{
    public GetEventByIdQueryValidator()
    {
        this.RuleFor(x => x.Id)
            .NotEmpty();
    }
}
