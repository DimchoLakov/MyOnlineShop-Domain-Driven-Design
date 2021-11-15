namespace MyOnlineShop.Domain.Ordering.Factories
{
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Ordering.Models.Orders;

    public interface IOrderFactory : IFactory<Order>
    {
        IOrderFactory WithUserId(string userId);

        IOrderFactory WithAddress(Address address);

        IOrderFactory WithAddress(
            string addressLine,
            string postCode,
            string town,
            string country);

        IOrderFactory WithStatus(OrderStatus status);
    }
}
