namespace MyOnlineShop.Domain.Shopping.Repositories
{
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Shopping.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IShoppingCartDomainRepository : IDomainRepository<ShoppingCart>
    {
        Task<ShoppingCart> Find(int id, CancellationToken cancellationToken = default);

        Task<ShoppingCart> Find(string userId, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        
        Task<bool> Delete(string userId, CancellationToken cancellationToken = default);

        Task<IEnumerable<ShoppingCartItem>> GetCartItems(int shoppingCartId, CancellationToken cancellationToken = default!);

        Task<IEnumerable<ShoppingCartItem>> GetCartItems(string userId, CancellationToken cancellationToken = default!);
    }
}
