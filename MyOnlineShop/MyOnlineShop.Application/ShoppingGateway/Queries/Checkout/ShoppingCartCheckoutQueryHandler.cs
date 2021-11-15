namespace MyOnlineShop.Application.ShoppingGateway.Queries.Checkout
{
    using MediatR;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Application.Identity;
    using MyOnlineShop.Application.Shopping;
    using MyOnlineShop.Application.ShoppingGateway.Commands.Checkout;
    using MyOnlineShop.Application.ShoppingGateway.Commands.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class ShoppingCartCheckoutQueryHandler : IRequestHandler<ShoppingCartCheckoutQuery, ShoppingCartCheckoutCommand>
    {
        private readonly IShoppingCartQueryRepository shoppingCartQueryRepository;
        private readonly IIdentity identity;

        public ShoppingCartCheckoutQueryHandler(
            IShoppingCartQueryRepository shoppingCartQueryRepository,
            IIdentity identity)
        {
            this.shoppingCartQueryRepository = shoppingCartQueryRepository;
            this.identity = identity;
        }

        public async Task<ShoppingCartCheckoutCommand> Handle(
            ShoppingCartCheckoutQuery request, 
            CancellationToken cancellationToken)
        {
            var cartItems = await this.shoppingCartQueryRepository
                                      .GetCartListing<CartItemCheckoutOutputModel>(request.UserId, cancellationToken);

            var user = await this.identity.GetUserById(request.UserId);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.UserId);
            }

            var shoppingCartCheckoutCommand = new ShoppingCartCheckoutCommand(
                request.UserId,
                user.FirstName,
                user.LastName,
                cartItems);

            return shoppingCartCheckoutCommand;
        }
    }
}
