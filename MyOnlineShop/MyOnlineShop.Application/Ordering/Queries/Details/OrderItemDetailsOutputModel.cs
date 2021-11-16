namespace MyOnlineShop.Application.Ordering.Queries.Details
{
    using MyOnlineShop.Application.Ordering.Queries.Common;

    public class OrderItemDetailsOutputModel : OrderItemOutputModel
    {
        public string Description { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public decimal Price => this.ProductPrice * this.Quantity;
    }
}
