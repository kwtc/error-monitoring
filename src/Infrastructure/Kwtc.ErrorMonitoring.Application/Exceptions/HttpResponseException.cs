namespace Kwtc.ErrorMonitoring.Application.Exceptions;

public class HttpResponseException : Exception
{
    public int StatusCode { get; }
    public object? Value { get; }

    public HttpResponseException(int statusCode, object? value = null) => (this.StatusCode, this.Value) = (statusCode, value);
}
