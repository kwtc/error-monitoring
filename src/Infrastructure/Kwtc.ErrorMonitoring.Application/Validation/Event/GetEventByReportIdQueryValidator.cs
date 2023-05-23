namespace Kwtc.ErrorMonitoring.Application.Validation.Event;

using Events.Queries;
using FluentValidation;

public class GetEventByReportIdQueryValidator : AbstractValidator<GetEventByReportIdQuery>
{
    public GetEventByReportIdQueryValidator()
    {
        this.RuleFor(x => x.ReportId)
            .NotEmpty()
            .WithMessage("ReportId is required.");
    }
}
