namespace MyOnlineShop.Domain.Catalog.Events
{
    using MyOnlineShop.Domain.Common;

    public class ProductNameUpdatedEvent : IDomainEvent
    {
        public ProductNameUpdatedEvent(
            int productId,
            string productName)
        {
            this.ProductId = productId;
            this.ProductName = productName;
        }

        public int ProductId { get; private set; }

        public string ProductName { get; private set; }
    }
}
