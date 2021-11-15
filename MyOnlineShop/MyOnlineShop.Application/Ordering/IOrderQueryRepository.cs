namespace MyOnlineShop.Application.Ordering
{
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Domain.Ordering.Models.Orders;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IOrderQueryRepository : IQueryRepository<Order>
    {
        Task<IEnumerable<TOutputModel>> GetOrderItemsById<TOutputModel>(int id, CancellationToken cancellationToken = default!);
    }
}
