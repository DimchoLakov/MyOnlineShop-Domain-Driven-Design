namespace MyOnlineShop.Application.Ordering.Queries.Details.Models
{
    using MyOnlineShop.Application.Common.Mapping;
    using MyOnlineShop.Application.Ordering.Queries.Common;
    using MyOnlineShop.Domain.Ordering.Models.Orders;

    public class OrderItemDetailsOutputModel : OrderItemOutputModel, IMapFrom<OrderItem>
    {
        public string Description { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public decimal Price => this.ProductPrice * this.Quantity;
    }
}
