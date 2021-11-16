namespace MyOnlineShop.Infrastructure.Ordering
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyOnlineShop.Application.Ordering;
    using MyOnlineShop.Domain.Ordering.Models.Orders;
    using MyOnlineShop.Domain.Ordering.Repositories;
    using MyOnlineShop.Infrastructure.Common.Persistance;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class OrderRepository : DataRepository<IOrderingDbContext, Order>,
        IOrderDomainRepository,
        IOrderQueryRepository
    {
        private readonly IMapper mapper;

        public OrderRepository(
            IOrderingDbContext dbContext,
            IMapper mapper)
            : base(dbContext)
        {
            this.mapper = mapper;
        }

        public async Task<Order> Find(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await this.All()
                             .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<Order> FindWithOrderItems(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await this.All()
                             .Where(o => o.Id == id)
                             .Include(o => o.OrderItems)
                             .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<TOutputModel>> GetOrderItemsByOrderId<TOutputModel>(
            int id,
            CancellationToken cancellationToken = default)
        {
            var orderItems = await this.Data
                                       .Orders
                                       .Where(o => o.Id == id)
                                       .SelectMany(o => o.OrderItems)
                                       .ToListAsync(cancellationToken);

            return this.mapper
                       .Map<IEnumerable<OrderItem>, IEnumerable<TOutputModel>>(orderItems);
        }

        public async Task<IEnumerable<TOutputModel>> GetOrdersByUserId<TOutputModel>(
            string userId,
            CancellationToken cancellationToken = default)
        {
            var orders = await this.All()
                                   .Include(o => o.OrderItems)
                                   .Where(o => o.UserId == userId)
                                   .ToListAsync(cancellationToken);

            return this.mapper
                       .Map<IEnumerable<Order>, IEnumerable<TOutputModel>>(orders);
        }
    }
}
