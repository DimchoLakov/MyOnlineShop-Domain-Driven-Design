namespace MyOnlineShop.Application.Shopping
{
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Domain.Shopping.Models;

    public interface IShoppingCartQueryRepository : IQueryRepository<ShoppingCart>
    {
    }
}
