namespace MyOnlineShop.Domain.Ordering.Models.Orders
{
    using MyOnlineShop.Domain.Common.Models;

    using System;
    using System.Collections.Generic;

    public class Order : Entity<int>
    {
        private readonly List<OrderItem> orderItems;

        internal Order(
            int customerId,
            int deliveryAddressId,
            int billingAddressId,
            OrderStatus orderStatus,
            decimal discount,
            decimal deliveryFee,
            int? invoiceId,
            int? paymentId)
        {
            this.orderItems = new List<OrderItem>();
            this.OrderDate = DateTime.Now;

            this.CustomerId = customerId;
            this.DeliveryAddressId = deliveryAddressId;
            this.BillingAddressId = billingAddressId;
            this.OrderStatus = orderStatus;
            this.Discount = discount;
            this.DeliveryFee = deliveryFee;
            this.InvoiceId = invoiceId;
            this.PaymentId = paymentId;
        }

        public DateTime OrderDate { get; private set; }

        public int CustomerId { get; private set; }

        public int DeliveryAddressId { get; private set; }

        public int BillingAddressId { get; private set; }

        public int? InvoiceId { get; private set; }

        public int? PaymentId { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        public decimal Discount { get; private set; }

        public decimal DeliveryFee { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => this.orderItems.AsReadOnly();
    }
}