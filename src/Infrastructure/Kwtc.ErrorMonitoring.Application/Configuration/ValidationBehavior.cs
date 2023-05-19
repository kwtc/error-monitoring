namespace Kwtc.ErrorMonitoring.Application.Configuration;

using FluentValidation;
using MediatR;

internal sealed class ValidationBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult> where TRequest : notnull
{
    private readonly IValidator<TRequest> validator;

    public ValidationBehavior(IValidator<TRequest> validator)
    {
        this.validator = validator;
    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        await this.validator.ValidateAndThrowAsync(request, cancellationToken);

        return await next();
    }
}
