namespace MyOnlineShop.Domain.Ordering.Models.Orders
{
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Common.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Order : Entity<int>, IAggregateRoot
    {
        private readonly List<OrderItem> orderItems;

        internal Order(
            string userId,
            Address address,
            OrderStatus orderStatus)
        {
            this.UserId = userId;
            this.OrderStatus = orderStatus;
            this.Address = address;

            this.orderItems = new List<OrderItem>();
            this.OrderDate = DateTime.UtcNow;
        }

        private Order(string userId)
        {
            this.UserId = userId;
            this.OrderStatus = OrderStatus.Submitted;
            this.Address = default!;

            this.orderItems = new List<OrderItem>();
            this.OrderDate = DateTime.UtcNow;
        }

        public string UserId { get; private set; }

        public DateTime OrderDate { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => this.orderItems.AsReadOnly();

        public void AddOrderItem(
            int productId,
            string name,
            string description,
            decimal productPrice,
            int quantity,
            string imageUrl)
        {
            this.AddOrderItem(new OrderItem(
                    productId,
                    name,
                    description,
                    productPrice,
                    quantity,
                    imageUrl));
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            this.orderItems.Add(orderItem);
        }

        public void RemoveCartItem(OrderItem orderItem)
        {
            this.orderItems.Remove(orderItem);
        }

        public OrderItem? GetOrderItem(int productId)
        {
            return this.orderItems
                       .FirstOrDefault(c => c.ProductId == productId);
        }

        public void Clear()
        {
            this.orderItems.Clear();
        }
    }
}