namespace Kwtc.ErrorMonitoring.Domain.Report;

public class Trace
{
    public Guid ExceptionId { get; set; }

    public string File { get; set; } = default!;

    public int LineNumber { get; set; }

    public string Method { get; set; } = default!;
}
