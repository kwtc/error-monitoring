namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.Models.ErrorReport;
using Models;

public class ErrorReportMapper : IMapper<ReportPayload, ErrorReport>
{
    public void Map(ReportPayload source, ErrorReport target)
    {
        target.AppId = source.AppId;
    }
}
