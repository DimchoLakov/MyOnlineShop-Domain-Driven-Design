namespace MyOnlineShop.Application.Ordering.Queries.Mine
{
    using MediatR;
    using MyOnlineShop.Application.Ordering.Queries.Common;
    using System.Collections.Generic;

    public class MyOrdersQuery : IRequest<IEnumerable<OrderOutputModel>>
    {
        public MyOrdersQuery(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; private set; }
    }
}
