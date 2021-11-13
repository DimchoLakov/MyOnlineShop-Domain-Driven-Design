namespace MyOnlineShop.Domain.Catalog.Events
{
    using MyOnlineShop.Domain.Common;

    public class ProductImageUrlUpdatedEvent : IDomainEvent
    {
        public ProductImageUrlUpdatedEvent(
            int productId,
            string imageUrl)
        {
            this.ProductId = productId;
            this.ImageUrl = imageUrl;
        }

        public int ProductId { get; private set; }

        public string ImageUrl { get; private set; }
    }
}
