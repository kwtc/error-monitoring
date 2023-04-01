namespace Kwtc.ErrorMonitoring.Application.Reports.Commands;

using Domain.Report;
using FluentValidation;
using MediatR;
using Persistence.Reports;
using Validators;

public record PersistReportCommand(Guid ClientId, Report Report) : IRequest<Report>;

internal sealed class PersistReportCommandHandler : IRequestHandler<PersistReportCommand, Report>
{
    private readonly IReportRepository reportRepository;

    public PersistReportCommandHandler(IReportRepository reportRepository)
    {
        this.reportRepository = reportRepository;
    }

    public async Task<Report> Handle(PersistReportCommand request, CancellationToken cancellationToken)
    {
        await new PersistReportValidator().ValidateAndThrowAsync(request.Report, cancellationToken);

        return await this.reportRepository.AddAsync(request.Report, cancellationToken);
    }
}
