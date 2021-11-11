namespace MyOnlineShop.Domain.Shopping.Factories
{
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Shopping.Models;

    public interface IShoppingCartFactory : IFactory<ShoppingCart>
    {
        IShoppingCartFactory WithUserId(string userId);
    }
}
