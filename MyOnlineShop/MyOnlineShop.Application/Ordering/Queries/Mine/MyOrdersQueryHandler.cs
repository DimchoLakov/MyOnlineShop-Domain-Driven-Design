namespace MyOnlineShop.Application.Ordering.Queries.Mine
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MyOrdersQueryHandler : IRequestHandler<MyOrdersQuery, IEnumerable<MyOrderOutputModel>>
    {
        private readonly IOrderQueryRepository orderQueryRepository;

        public MyOrdersQueryHandler(IOrderQueryRepository orderQueryRepository)
        {
            this.orderQueryRepository = orderQueryRepository;
        }

        public async Task<IEnumerable<MyOrderOutputModel>> Handle(
            MyOrdersQuery request, 
            CancellationToken cancellationToken)
        {
            return (await this.orderQueryRepository
                             .GetOrdersByUserId<MyOrderOutputModel>(request.UserId, cancellationToken))
                             .OrderByDescending(o => o.OrderDate)
                             .ToList();
        }
    }
}
