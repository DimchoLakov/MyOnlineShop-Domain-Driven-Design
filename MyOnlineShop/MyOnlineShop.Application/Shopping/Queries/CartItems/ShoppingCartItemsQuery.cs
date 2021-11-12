namespace MyOnlineShop.Application.Shopping.Queries.CartItems
{
    using MediatR;
    using MyOnlineShop.Application.Shopping.Queries.Common;
    using System.Collections.Generic;

    public class ShoppingCartItemsQuery : IRequest<IEnumerable<ShoppingCartItemOutputModel>>
    {
    }
}
