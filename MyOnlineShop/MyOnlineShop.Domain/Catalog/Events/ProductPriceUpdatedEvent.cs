namespace MyOnlineShop.Domain.Catalog.Events
{
    using MyOnlineShop.Domain.Common;

    public class ProductPriceUpdatedEvent : IDomainEvent
    {
        public ProductPriceUpdatedEvent(
            int productId,
            decimal productPrice)
        {
            this.ProductId = productId;
            this.ProductPrice = productPrice;
        }

        public int ProductId { get; private set; }

        public decimal ProductPrice { get; private set; }
    }
}
