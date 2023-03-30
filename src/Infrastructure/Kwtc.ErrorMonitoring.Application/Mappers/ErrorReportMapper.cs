namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.ErrorReport;
using Models.Payload.ErrorReport;

public class ErrorReportMapper : IMapper<ErrorReportPayload, ErrorReport>
{
    public void Map(ErrorReportPayload source, ErrorReport target)
    {
        target.ApiKey = source.ApiKey;
    }
}
