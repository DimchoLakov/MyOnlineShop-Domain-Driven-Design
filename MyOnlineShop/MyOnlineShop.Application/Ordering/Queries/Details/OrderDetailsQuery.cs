namespace MyOnlineShop.Application.Ordering.Queries.Details
{
    using MediatR;
    using MyOnlineShop.Application.Ordering.Queries.Details.Models;

    public class OrderDetailsQuery : IRequest<OrderDetailsOutputModel>
    {
        public OrderDetailsQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}
