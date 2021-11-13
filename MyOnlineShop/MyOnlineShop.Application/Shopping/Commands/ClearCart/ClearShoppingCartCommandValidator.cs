namespace MyOnlineShop.Application.Shopping.Commands.ClearCart
{
    using FluentValidation;

    public class ClearShoppingCartCommandValidator : AbstractValidator<ClearShoppingCartCommand>
    {
        public ClearShoppingCartCommandValidator()
        {
            this.RuleFor(c => c.UserId)
                .NotEmpty();
        }
    }
}
