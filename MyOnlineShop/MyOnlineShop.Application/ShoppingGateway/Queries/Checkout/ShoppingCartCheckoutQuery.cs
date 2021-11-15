namespace MyOnlineShop.Application.ShoppingGateway.Queries.Checkout
{
    using MediatR;
    using MyOnlineShop.Application.ShoppingGateway.Commands.Checkout;

    public class ShoppingCartCheckoutQuery : IRequest<ShoppingCartCheckoutCommand>
    {
        public ShoppingCartCheckoutQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; private set; }
    }
}
