namespace MyOnlineShop.Domain.Shopping.Factories
{
    using MyOnlineShop.Domain.Shopping.Models;

    public class ShoppingCartFactory : IShoppingCartFactory
    {
        private string userId = default!;

        private bool isUserIdSet;

        public IShoppingCartFactory WithUserId(string userId)
        {
            this.userId = userId;
            this.isUserIdSet = true;

            return this;
        }

        public Models.ShoppingCart Build()
        {
            if (!this.isUserIdSet)
            {
                throw new Exceptions.InvalidShoppingCartException($"Property {nameof(this.userId)} must be set!");
            }

            return new ShoppingCart(this.userId);
        }
    }
}
