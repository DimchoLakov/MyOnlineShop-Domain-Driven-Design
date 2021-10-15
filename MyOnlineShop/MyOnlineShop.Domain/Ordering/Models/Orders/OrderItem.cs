namespace MyOnlineShop.Domain.Ordering.Models.Orders
{
    using MyOnlineShop.Domain.Common.Models;

    public class OrderItem : Entity<int>
    {
        internal OrderItem(
            int quantity,
            decimal price,
            int productId,
            Order order)
        {
            this.Quantity = quantity;
            this.Price = price;
            this.ProductId = productId;
            this.Order = order;
        }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public int ProductId { get; private set; }

        public Order Order { get; private set; }
    }
}
