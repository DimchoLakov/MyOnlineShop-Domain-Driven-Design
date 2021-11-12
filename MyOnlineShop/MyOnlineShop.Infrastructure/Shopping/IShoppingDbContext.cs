namespace MyOnlineShop.Infrastructure.Shopping
{
    using Microsoft.EntityFrameworkCore;
    using MyOnlineShop.Domain.Shopping.Models;
    using MyOnlineShop.Infrastructure.Common.Persistance;

    internal interface IShoppingDbContext : IDbContext
    {
        DbSet<ShoppingCart> ShoppingCarts { get; }
        
        DbSet<ShoppingCartItem> ShoppingCartItems { get; }
    }
}
