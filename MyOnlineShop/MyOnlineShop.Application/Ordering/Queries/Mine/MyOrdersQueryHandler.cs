namespace MyOnlineShop.Application.Ordering.Queries.Mine
{
    using MediatR;
    using MyOnlineShop.Application.Ordering.Queries.Common;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MyOrdersQueryHandler : IRequestHandler<MyOrdersQuery, IEnumerable<OrderOutputModel>>
    {
        private readonly IOrderQueryRepository orderQueryRepository;

        public MyOrdersQueryHandler(IOrderQueryRepository orderQueryRepository)
        {
            this.orderQueryRepository = orderQueryRepository;
        }

        public async Task<IEnumerable<OrderOutputModel>> Handle(
            MyOrdersQuery request, 
            CancellationToken cancellationToken)
        {
            return (await this.orderQueryRepository
                             .GetOrdersByUserId<OrderOutputModel>(request.UserId, cancellationToken))
                             .OrderByDescending(o => o.OrderDate)
                             .ToList();
        }
    }
}
