namespace MyOnlineShop.Application.Shopping.Queries.CartItems
{
    using MediatR;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Application.Shopping.Queries.Common;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class ShoppingCartItemsQueryHandler : IRequestHandler<ShoppingCartItemsQuery, IEnumerable<ShoppingCartItemOutputModel>>
    {
        private readonly ICurrentUser currentUser;
        private readonly IShoppingCartQueryRepository shoppingCartQueryRepository;

        public ShoppingCartItemsQueryHandler(
            ICurrentUser currentUser, IShoppingCartQueryRepository shoppingCartQueryRepository)
        {
            this.currentUser = currentUser;
            this.shoppingCartQueryRepository = shoppingCartQueryRepository;
        }

        public async Task<IEnumerable<ShoppingCartItemOutputModel>> Handle(
            ShoppingCartItemsQuery request,
            CancellationToken cancellationToken)
        {
            string currentUserId = this.currentUser.UserId;

            return await this.shoppingCartQueryRepository
                .GetCartListing<ShoppingCartItemOutputModel>(currentUserId, cancellationToken);
        }
    }
}
