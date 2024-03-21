using FluentValidation;
using MediatR;

namespace Ecommerce.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var errors = validationResults
                .Where(w => !w.IsValid)
                .SelectMany(sm => sm.Errors)
                .Select(s => new ValidationError
                {
                    PropertyName = s.PropertyName,
                    ErrorMessage = s.ErrorMessage
                })
                .ToList();

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }

            var response = await next();
            return response;
        }
    }

    public class ValidationException : Exception        
    {
        public readonly IReadOnlyCollection<ValidationError> _errors;
        public ValidationException(IReadOnlyCollection<ValidationError> errors) : base("Validation failed")
        {
            _errors = errors;
        }
    }

    public record ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }

}
