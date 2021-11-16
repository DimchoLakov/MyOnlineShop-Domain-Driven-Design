namespace MyOnlineShop.Application.Ordering
{
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Application.Ordering.Queries.Details.Models;
    using MyOnlineShop.Domain.Ordering.Models.Orders;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IOrderQueryRepository : IQueryRepository<Order>
    {
        Task<IEnumerable<TOutputModel>> GetOrdersByUserId<TOutputModel>(string userId, CancellationToken cancellationToken = default!);

        Task<IEnumerable<TOutputModel>> GetOrderItemsByOrderId<TOutputModel>(int id, CancellationToken cancellationToken = default!);

        Task<OrderDetailsOutputModel> GetDetailsByIdWithOrderItems(int id, CancellationToken cancellationToken = default!);
    }
}
