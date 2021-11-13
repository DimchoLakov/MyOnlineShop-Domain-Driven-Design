namespace MyOnlineShop.Application.Shopping.Commands.RemoveProductFromCart
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Application.Shopping.Commands.RemoveCartItem;
    using MyOnlineShop.Domain.Shopping.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand, Result>
    {
        private readonly IShoppingCartDomainRepository shoppingCartDomainRepository;

        public RemoveCartItemCommandHandler(IShoppingCartDomainRepository shoppingCartDomainRepository)
        {
            this.shoppingCartDomainRepository = shoppingCartDomainRepository;
        }

        public async Task<Result> Handle(
            RemoveCartItemCommand request, 
            CancellationToken cancellationToken)
        {
            var shoppingCart = await this.shoppingCartDomainRepository
                                         .FindWithCartItems(request.UserId, cancellationToken);
            if (shoppingCart == null)
            {
                throw new NotFoundException(nameof(shoppingCart), request.UserId);
            }

            var cartItem = shoppingCart.GetCartItem(request.ProductId);
            if (cartItem == null)
            {
                throw new NotFoundException(nameof(cartItem), request.ProductId);
            }

            shoppingCart.RemoveCartItem(cartItem);

            await this.shoppingCartDomainRepository
                      .SaveAsync(shoppingCart, cancellationToken);

            return Result.Success;
        }
    }
}
