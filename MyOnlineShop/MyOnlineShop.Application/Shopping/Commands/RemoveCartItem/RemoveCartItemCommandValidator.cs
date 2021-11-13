namespace MyOnlineShop.Application.Shopping.Commands.RemoveCartItem
{
    using FluentValidation;

    public class RemoveCartItemCommandValidator : AbstractValidator<RemoveCartItemCommand>
    {
        public RemoveCartItemCommandValidator()
        {
            this.RuleFor(r => r.ProductId)
                .Must(p => p > 0);

            this.RuleFor(r => r.UserId)
                .NotEmpty();
        }
    }
}
