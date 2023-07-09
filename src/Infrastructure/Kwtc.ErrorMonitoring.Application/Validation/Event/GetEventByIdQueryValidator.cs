using FluentValidation;
using Kwtc.ErrorMonitoring.Application.Events.Queries;

namespace Kwtc.ErrorMonitoring.Application.Validation.Event;

public class GetEventByIdQueryValidator : AbstractValidator<GetEventByIdQuery>
{
    public GetEventByIdQueryValidator()
    {
        this.RuleFor(x => x.Id)
            .NotEmpty();
    }
}
