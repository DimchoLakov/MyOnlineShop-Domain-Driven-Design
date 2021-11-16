namespace MyOnlineShop.Application.Ordering.Queries.Common
{
    using MyOnlineShop.Application.Common.Mapping;
    using MyOnlineShop.Domain.Ordering.Models.Orders;

    public class OrderItemOutputModel : IMapFrom<OrderItem>
    {
        public int Quantity { get; set; }

        public string Name { get; set; } = default!;

        public decimal ProductPrice { get; set; }
    }
}
