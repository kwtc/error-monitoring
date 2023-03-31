namespace Kwtc.ErrorMonitoring.Application.ErrorReports.Commands;

using Domain.Report;
using FluentValidation;
using MediatR;
using Persistence.Reports;
using Validators.ErrorReport;

public record PersistErrorReportCommand(Guid ClientId, Report Report) : IRequest<Report>;

internal sealed class RegisterErrorReportCommandHandler : IRequestHandler<PersistErrorReportCommand, Report>
{
    private readonly IErrorReportRepository errorReportRepository;

    public RegisterErrorReportCommandHandler(IErrorReportRepository errorReportRepository)
    {
        this.errorReportRepository = errorReportRepository;
    }

    public async Task<Report> Handle(PersistErrorReportCommand request, CancellationToken cancellationToken)
    {
        await new PersistErrorReportValidator().ValidateAndThrowAsync(request.Report, cancellationToken);

        return await this.errorReportRepository.AddAsync(request.Report, cancellationToken);
    }
}
