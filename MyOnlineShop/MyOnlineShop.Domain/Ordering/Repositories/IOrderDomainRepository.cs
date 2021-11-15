namespace MyOnlineShop.Domain.Ordering.Repositories
{
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Ordering.Models.Orders;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IOrderDomainRepository : IDomainRepository<Order>
    {
        Task<Order> Find(int id, CancellationToken cancellationToken = default);

        Task<Order> FindWithOrderItems(int id, CancellationToken cancellationToken = default);
    }
}
