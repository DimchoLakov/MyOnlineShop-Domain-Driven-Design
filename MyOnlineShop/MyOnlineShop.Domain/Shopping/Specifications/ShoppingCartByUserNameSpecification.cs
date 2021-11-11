namespace MyOnlineShop.Domain.Shopping.Specifications
{
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Shopping.Models;
    using System;
    using System.Linq.Expressions;

    public class ShoppingCartByUserNameSpecification : Specification<ShoppingCart>
    {
        private readonly string? userId;

        public ShoppingCartByUserNameSpecification(string? userId)
        {
            this.userId = userId;
        }

        protected override bool Include => this.userId != null;

        public override Expression<Func<ShoppingCart, bool>> ToExpression()
        {
            return shoppingCart => shoppingCart.UserId == this.userId;
        }
    }
}
