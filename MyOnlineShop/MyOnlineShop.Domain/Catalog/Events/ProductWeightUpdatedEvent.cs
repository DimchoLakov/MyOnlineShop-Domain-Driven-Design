namespace MyOnlineShop.Domain.Catalog.Events
{
    using MyOnlineShop.Domain.Common;

    public class ProductWeightUpdatedEvent : IDomainEvent
    {
        public ProductWeightUpdatedEvent(
            int productId,
            double productWeight)
        {
            this.ProductId = productId;
            this.ProductWeight = productWeight;
        }

        public int ProductId { get; private set; }

        public double ProductWeight { get; private set; }
    }
}
