namespace Kwtc.ErrorMonitoring.Domain.Models;

[Serializable]
public class Report
{
    public string? AppId { get; set; }
    public Exception? OriginalException { get; set; }
}
