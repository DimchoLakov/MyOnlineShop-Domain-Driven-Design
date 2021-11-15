namespace MyOnlineShop.Application.ShoppingGateway.Commands.Checkout
{
    using FluentValidation;

    public class ShoppingCartCheckoutCommandValidator : AbstractValidator<ShoppingCartCheckoutCommand>
    {
        public ShoppingCartCheckoutCommandValidator()
        {
            this.RuleFor(s => s.AddressInputModel.AddressLine)
                .NotEmpty();

            this.RuleFor(s => s.AddressInputModel.Country)
                .NotEmpty();

            this.RuleFor(s => s.AddressInputModel.PostCode)
                .NotEmpty();

            this.RuleFor(s => s.AddressInputModel.Town)
                .NotEmpty();
        }
    }
}
