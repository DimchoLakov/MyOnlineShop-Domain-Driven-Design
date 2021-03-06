namespace MyOnlineShop.Infrastructure.Shopping.Repositories
{
    using AutoMapper;
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
        IShoppingCartDomainRepository,
        IShoppingCartQueryRepository
    {
        private readonly IMapper mapper;

        public ShoppingCartRepository(
            IShoppingDbContext dbContext,
            IMapper mapper)
            : base(dbContext)
        {
            this.mapper = mapper;
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

        public async Task<ShoppingCart> FindWithCartItems(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await this.Data
                       .ShoppingCarts
                       .Include(s => s.CartItems)
                       .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<ShoppingCart> FindWithCartItems(
            string userId,
            CancellationToken cancellationToken = default)
        {
            return await this.Data
                       .ShoppingCarts
                       .Include(s => s.CartItems)
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

        public async Task<IEnumerable<TOutputModel>> GetCartListing<TOutputModel>(
            string userId,
            CancellationToken cancellationToken = default)
        {
            var cartItems = this.Data
                .ShoppingCarts
                .Where(s => s.UserId == userId)
                .SelectMany(s => s.CartItems);

            return await this.mapper
                .ProjectTo<TOutputModel>(cartItems)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> UpdateCartItemsWithProductDescription(
            int productId,
            string newProductDescription,
            CancellationToken cancellationToken = default)
        {
            var cartItemsToUpdate = await this.Data
                                              .ShoppingCartItems
                                              .Where(c => c.ProductId == productId)
                                              .ToListAsync(cancellationToken);

            foreach (var cartItem in cartItemsToUpdate)
            {
                cartItem.UpdateProductDescription(newProductDescription);
            }

            if (cartItemsToUpdate.Any())
            {
                this.Data
                    .ShoppingCartItems
                    .UpdateRange(cartItemsToUpdate);

                return await this.Data
                                 .SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        public async Task<int> UpdateCartItemsWithProductName(
            int productId,
            string newProductName,
            CancellationToken cancellationToken = default)
        {
            var cartItemsToUpdate = await this.Data
                                              .ShoppingCartItems
                                              .Where(c => c.ProductId == productId)
                                              .ToListAsync(cancellationToken);

            foreach (var cartItem in cartItemsToUpdate)
            {
                cartItem.UpdateProductName(newProductName);
            }

            if (cartItemsToUpdate.Any())
            {
                this.Data
                    .ShoppingCartItems
                    .UpdateRange(cartItemsToUpdate);

                return await this.Data
                                 .SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        public async Task<int> UpdateCartItemsWithProductPrice(
            int productId,
            decimal newProductPrice,
            CancellationToken cancellationToken = default)
        {
            var cartItemsToUpdate = await this.Data
                                              .ShoppingCartItems
                                              .Where(c => c.ProductId == productId)
                                              .ToListAsync(cancellationToken);

            foreach (var cartItem in cartItemsToUpdate)
            {
                cartItem.UpdateProductPrice(newProductPrice);
            }

            if (cartItemsToUpdate.Any())
            {
                this.Data
                    .ShoppingCartItems
                    .UpdateRange(cartItemsToUpdate);

                return await this.Data
                                 .SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        public async Task<int> UpdateCartItemsWithProductWeight(
            int productId,
            double newProductWeight,
            CancellationToken cancellationToken = default)
        {
            var cartItemsToUpdate = await this.Data
                                              .ShoppingCartItems
                                              .Where(c => c.ProductId == productId)
                                              .ToListAsync(cancellationToken);

            foreach (var cartItem in cartItemsToUpdate)
            {
                cartItem.UpdateProductWeight(newProductWeight);
            }

            if (cartItemsToUpdate.Any())
            {
                this.Data
                    .ShoppingCartItems
                    .UpdateRange(cartItemsToUpdate);

                return await this.Data
                                 .SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        public async Task<int> UpdateCartItemsWithProductImageUrl(
            int productId, 
            string newProductImageUrl, 
            CancellationToken cancellationToken = default)
        {
            var cartItemsToUpdate = await this.Data
                                              .ShoppingCartItems
                                              .Where(c => c.ProductId == productId)
                                              .ToListAsync(cancellationToken);

            foreach (var cartItem in cartItemsToUpdate)
            {
                cartItem.UpdateProductImageUrl(newProductImageUrl);
            }

            if (cartItemsToUpdate.Any())
            {
                this.Data
                    .ShoppingCartItems
                    .UpdateRange(cartItemsToUpdate);

                return await this.Data
                                 .SaveChangesAsync(cancellationToken);
            }

            return 0;
        }
    }
}
