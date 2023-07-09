using Kwtc.ErrorMonitoring.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kwtc.ErrorMonitoring.Api.Filters;

public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is not HttpResponseException exception)
        {
            return;
        }

        context.Result = new ObjectResult(exception.Value)
        {
            StatusCode = exception.StatusCode
        };

        context.ExceptionHandled = true;
    }
}
