namespace MyOnlineShop.Application.ShoppingGateway.Commands.Checkout
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Domain.Ordering.Factories;
    using MyOnlineShop.Domain.Ordering.Models.Orders;
    using MyOnlineShop.Domain.Ordering.Repositories;
    using MyOnlineShop.Domain.Shopping.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class ShoppingCartCheckoutCommandHandler : IRequestHandler<ShoppingCartCheckoutCommand, Result>
    {
        private readonly IOrderDomainRepository orderDomainRepository;
        private readonly IOrderFactory orderFactory;
        private readonly IShoppingCartDomainRepository shoppingCartDomainRepository;
        private readonly ICurrentUser currentUser;

        public ShoppingCartCheckoutCommandHandler(
            IOrderDomainRepository orderDomainRepository,
            IOrderFactory orderFactory,
            IShoppingCartDomainRepository shoppingCartDomainRepository,
            ICurrentUser currentUser)
        {
            this.orderDomainRepository = orderDomainRepository;
            this.orderFactory = orderFactory;
            this.shoppingCartDomainRepository = shoppingCartDomainRepository;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            ShoppingCartCheckoutCommand request,
            CancellationToken cancellationToken)
        {
            if (this.currentUser.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(currentUser), request.UserId);
            }

            var newOrder = this.orderFactory
                               .WithUserId(request.UserId)
                               .WithStatus(OrderStatus.Submitted)
                               .WithAddress(
                                       request
                                           .AddressInputModel
                                           .AddressLine,

                                       request
                                           .AddressInputModel
                                           .PostCode,

                                       request
                                           .AddressInputModel
                                           .Town,

                                       request
                                           .AddressInputModel
                                           .Country)
                               .Build();

            var cartItems = await this.shoppingCartDomainRepository
                                      .GetCartItems(request.UserId, cancellationToken);

            foreach (var cartItem in cartItems)
            {
                newOrder.AddOrderItem(
                    cartItem.ProductId,
                    cartItem.ProductName,
                    cartItem.ProductDescription,
                    cartItem.ProductPrice,
                    cartItem.Quantity,
                    cartItem.ProductImageUrl);
            }

            await this.orderDomainRepository
                      .SaveAsync(newOrder, cancellationToken);

            await this.shoppingCartDomainRepository
                      .Delete(request.UserId, cancellationToken);

            return Result.Success;
        }
    }
}
