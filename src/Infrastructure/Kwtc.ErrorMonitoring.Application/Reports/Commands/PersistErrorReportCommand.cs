namespace Kwtc.ErrorMonitoring.Application.Reports.Commands;

using MediatR;
using Models;
using Persistence.Abstractions.Reports;

public record SaveErrorReportCommand(Report Report) : IRequest<Report>;

internal sealed class SaveErrorReportCommandHandler : IRequestHandler<SaveErrorReportCommand, Report>
{
    private readonly IReportRepository reportRepository;

    public SaveErrorReportCommandHandler(IReportRepository reportRepository)
    {
        this.reportRepository = reportRepository;
    }

    public async Task<Report> Handle(SaveErrorReportCommand request, CancellationToken cancellationToken)
    {
        // TODO: validate and map report
        var report = new Domain.Models.Report.Report();

        await this.reportRepository.AddAsync(report, cancellationToken);

        return request.Report;
    }
}
