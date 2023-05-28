namespace Kwtc.ErrorMonitoring.Domain.Event;

using System.ComponentModel;

public enum Severity
{
    [Description("info")]
    Info = 1,
    
    [Description("warning")]
    Warning = 2,
    
    [Description("error")]
    Error = 3
}
