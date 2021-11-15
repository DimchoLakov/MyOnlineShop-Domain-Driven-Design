namespace MyOnlineShop.Domain.Ordering.Factories
{
    using MyOnlineShop.Domain.Ordering.Exceptions;
    using MyOnlineShop.Domain.Ordering.Models.Orders;

    public class OrderFactory : IOrderFactory
    {
        private string userId = default!;
        private Address address = default!;
        private OrderStatus status = default!;

        private bool isUserIdSet;
        private bool isAddressSet;
        private bool isStatusSet;

        public IOrderFactory WithUserId(string userId)
        {
            this.userId = userId;
            this.isUserIdSet = true;

            return this;
        }

        public IOrderFactory WithAddress(
            string addressLine,
            string postCode,
            string town,
            string country)
        {
            return this.WithAddress(new Address(
                    addressLine,
                    postCode,
                    town,
                    country));
        }

        public IOrderFactory WithAddress(Address address)
        {
            this.address = address;
            this.isAddressSet = true;

            return this;
        }

        public IOrderFactory WithStatus(OrderStatus status)
        {
            this.status = status;
            this.isStatusSet = true;

            return this;
        }

        public Order Build()
        {
            if (!this.isUserIdSet ||
                !this.isAddressSet ||
                !this.isStatusSet)
            {
                throw new InvalidOrderException("User Id, Address and Order Status must be set!");
            }

            return new Order(
                this.userId,
                this.address,
                this.status);
        }
    }
}
