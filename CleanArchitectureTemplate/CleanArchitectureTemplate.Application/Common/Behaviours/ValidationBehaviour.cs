using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CleanArchitectureTemplate.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>(IValidator<TRequest>? validator = null)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validator is null)
            {
                return await next();
            }

            ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
            
            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors.ConvertAll(err => Error.Validation(
                    code: err.PropertyName,
                    description: err.ErrorMessage
                ));

            return (dynamic)errors;
        }
    }
}
