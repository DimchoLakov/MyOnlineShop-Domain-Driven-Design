namespace MyOnlineShop.Domain.Catalog.Events
{
    using MyOnlineShop.Domain.Common;

    public class ProductDescriptionUpdatedEvent : IDomainEvent
    {
        public ProductDescriptionUpdatedEvent(
            int productId,
            string productDescription)
        {
            this.ProductId = productId;
            this.ProductDescription = productDescription;
        }

        public int ProductId { get; private set; }

        public string ProductDescription { get; private set; }
    }
}
