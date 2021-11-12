namespace MyOnlineShop.Infrastructure.Shopping.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MyOnlineShop.Application.Shopping;
    using MyOnlineShop.Domain.Shopping.Models;
    using MyOnlineShop.Domain.Shopping.Repositories;
    using MyOnlineShop.Infrastructure.Common.Persistance;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShoppingCartRepository : DataRepository<IShoppingDbContext, ShoppingCart>,
        //IShoppingCartQueryRepository,
        IShoppingCartDomainRepository
    {
        public ShoppingCartRepository(IShoppingDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var shoppingCart = await this.Find(id, cancellationToken);
            if (shoppingCart == null)
            {
                return false;
            }

            this.Data
                .ShoppingCarts
                .Remove(shoppingCart);

            await this.Data
                      .SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> Delete(
            string userId,
            CancellationToken cancellationToken = default)
        {
            var shoppingCart = await this.Find(userId, cancellationToken);
            if (shoppingCart == null)
            {
                return false;
            }

            this.Data
                .ShoppingCarts
                .Remove(shoppingCart);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<ShoppingCart> Find(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await this.Data
                       .ShoppingCarts
                       .FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<ShoppingCart> Find(
            string userId,
            CancellationToken cancellationToken = default)
        {
            return await this.Data
                       .ShoppingCarts
                       .FirstOrDefaultAsync(s => s.UserId == userId, cancellationToken);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetCartItems(
            int shoppingCartId,
            CancellationToken cancellationToken = default)
        {
            return await this.Data
                .ShoppingCarts
                .Where(s => s.Id == shoppingCartId)
                .SelectMany(s => s.CartItems)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetCartItems(
            string userId,
            CancellationToken cancellationToken = default)
        {
            return await this.Data
                .ShoppingCarts
                .Where(s => s.UserId == userId)
                .SelectMany(s => s.CartItems)
                .ToListAsync(cancellationToken);
        }
    }
}
