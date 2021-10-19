namespace MyOnlineShop.Application.Common.Behaviours
{
    using FluentValidation;
    using MediatR;
    using MyOnlineShop.Application.Common.Exceptions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class RequestBehaviourPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public RequestBehaviourPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(
            TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            var validationContext = new ValidationContext<TRequest>(request);

            var errors = this.validators
                .Select(v => v.Validate(validationContext))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();

            if (errors.Any())
            {
                throw new ModelValidationException(errors);
            }

            return next();
        }
    }
}
