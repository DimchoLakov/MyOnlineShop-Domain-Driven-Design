namespace MyOnlineShop.Application.ShoppingGateway.Commands.AddProduct
{
    using FluentValidation;

    public class AddProductToShoppingCartCommandValidator : AbstractValidator<AddProductToShoppingCartCommand>
    {
        public AddProductToShoppingCartCommandValidator()
        {
            this.RuleFor(a => a.ProductId)
                .Must(q => q > 0);

            this.RuleFor(a => a.UserId)
                .NotEmpty();

            this.RuleFor(a => a.Quantity)
                .Must(q => q > 0);
        }
    }
}
