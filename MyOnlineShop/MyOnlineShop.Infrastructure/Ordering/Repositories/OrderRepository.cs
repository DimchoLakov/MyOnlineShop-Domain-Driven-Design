namespace MyOnlineShop.Infrastructure.Ordering
{
    using AutoMapper;
    using MyOnlineShop.Application.Ordering;
    using MyOnlineShop.Domain.Ordering.Models.Orders;
    using MyOnlineShop.Domain.Ordering.Repositories;
    using MyOnlineShop.Infrastructure.Common.Persistance;
    using System.Collections.Generic;
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

        public Task<Order> Find(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> FindWithOrderItems(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TOutputModel>> GetOrderItemsById<TOutputModel>(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
