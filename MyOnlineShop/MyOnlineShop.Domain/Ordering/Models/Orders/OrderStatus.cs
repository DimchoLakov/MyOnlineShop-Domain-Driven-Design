namespace MyOnlineShop.Domain.Ordering.Models.Orders
{
    using MyOnlineShop.Domain.Common.Models;

    public class OrderStatus : Enumeration
    {
        public static OrderStatus Submitted = new OrderStatus(1, nameof(Submitted));
        public static OrderStatus AwaitingValidation = new OrderStatus(2, nameof(AwaitingValidation));
        public static OrderStatus Paid = new OrderStatus(3, nameof(Paid));
        public static OrderStatus Shipped = new OrderStatus(4, nameof(Shipped));
        public static OrderStatus Completed = new OrderStatus(5, nameof(Completed));
        public static OrderStatus Cancelled = new OrderStatus(6, nameof(Cancelled));

        private OrderStatus(int value)
            : this(value, FromValue<OrderStatus>(value).Name)
        {
        }

        private OrderStatus(int value, string name) : base(value, name)
        {
        }
    }
}
