namespace MyOnlineShop.Application.Ordering.Queries.Mine
{
    using MediatR;
    using System.Collections.Generic;

    public class MyOrdersQuery : IRequest<IEnumerable<MyOrderOutputModel>>
    {
        public MyOrdersQuery(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; private set; }
    }
}
