namespace MyOnlineShop.Application.Ordering.Queries.Details
{
    using MediatR;
    using MyOnlineShop.Application.Ordering.Queries.Details.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public class OrderDetailsQueryHandler : IRequestHandler<OrderDetailsQuery, OrderDetailsOutputModel>
    {
        private readonly IOrderQueryRepository orderQueryRepository;

        public OrderDetailsQueryHandler(IOrderQueryRepository orderQueryRepository)
        {
            this.orderQueryRepository = orderQueryRepository;
        }

        public async Task<OrderDetailsOutputModel> Handle(
            OrderDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            return await this.orderQueryRepository
                             .GetDetailsByIdWithOrderItems(request.Id, cancellationToken);
        }
    }
}
