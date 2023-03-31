namespace Kwtc.ErrorMonitoring.Domain.Report;

public class Trace
{
    public string File { get; set; } = default!;
    public int LineNumber { get; set; }
    public string Method { get; set; } = default!;
}
