namespace MyOnlineShop.Application.Shopping
{
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Domain.Shopping.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IShoppingCartQueryRepository : IQueryRepository<ShoppingCart>
    {
        Task<IEnumerable<TOutputModel>> GetCartListing<TOutputModel>(
            string userId,
            CancellationToken cancellationToken = default);
    }
}
