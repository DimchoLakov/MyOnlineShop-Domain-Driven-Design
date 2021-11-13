namespace MyOnlineShop.Domain.Shopping.Models
{
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Common.Models;
    using MyOnlineShop.Domain.Shopping.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCart : Entity<int>, IAggregateRoot
    {
        private readonly List<ShoppingCartItem> cartItems;

        internal ShoppingCart(string userId)
        {
            this.ValidateUserId(userId);

            this.UserId = userId;

            this.UniqueId = Guid.NewGuid().ToString();
            this.cartItems = new List<ShoppingCartItem>();
        }

        public string UserId { get; private set; }

        public string UniqueId { get; private set; }

        public IReadOnlyCollection<ShoppingCartItem> CartItems => this.cartItems.AsReadOnly();

        public void AddCartItem(
            int productId,
            int quantity,
            string productName,
            double productWeight,
            decimal productPrice,
            string productDescription,
            string productImageUrl)
        {
            this.AddCartItem(new ShoppingCartItem(
                productId, 
                quantity, 
                productName, 
                productWeight, 
                productPrice, 
                productDescription, 
                productImageUrl));
        }

        public void AddCartItem(ShoppingCartItem cartItem)
        {
            this.cartItems.Add(cartItem);
        }

        public void RemoveCartItem(ShoppingCartItem cartItem)
        {
            this.cartItems.Remove(cartItem);
        }

        public ShoppingCartItem? GetCartItem(int productId)
        {
            return this.cartItems
                .FirstOrDefault(c => c.ProductId == productId);
        }

        public void Clear()
        {
            this.cartItems.Clear();
        }

        private void ValidateUserId(string userId)
        {
            Guard.AgainstEmptyString<InvalidShoppingCartException>(userId, nameof(this.UserId));
        }
    }
}
