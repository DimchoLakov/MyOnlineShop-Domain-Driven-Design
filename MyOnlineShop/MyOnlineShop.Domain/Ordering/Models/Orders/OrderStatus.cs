namespace MyOnlineShop.Domain.Ordering.Models.Orders
{
    using MyOnlineShop.Domain.Common.Models;

    public class OrderStatus : Enumeration
    {
        public static OrderStatus Pending = new OrderStatus(1, nameof(Pending));
        public static OrderStatus Cancelled = new OrderStatus(1, nameof(Cancelled));
        public static OrderStatus Completed = new OrderStatus(1, nameof(Completed));

        private OrderStatus(int value, string name) : base(value, name)
        {
        }
    }
}
