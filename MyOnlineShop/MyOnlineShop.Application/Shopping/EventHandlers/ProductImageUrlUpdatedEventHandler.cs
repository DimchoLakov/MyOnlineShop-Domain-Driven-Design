namespace MyOnlineShop.Application.Shopping.EventHandlers
{
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Domain.Catalog.Events;
    using MyOnlineShop.Domain.Shopping.Repositories;
    using System.Threading.Tasks;

    public class ProductImageUrlUpdatedEventHandler : IEventHandler<ProductImageUrlUpdatedEvent>
    {
        private readonly IShoppingCartDomainRepository shoppingCartDomainRepository;

        public ProductImageUrlUpdatedEventHandler(IShoppingCartDomainRepository shoppingCartDomainRepository)
        {
            this.shoppingCartDomainRepository = shoppingCartDomainRepository;
        }

        public async Task Handle(ProductImageUrlUpdatedEvent domainEvent)
        {
            await this.shoppingCartDomainRepository
                      .UpdateCartItemsWithProductImageUrl(domainEvent.ProductId, domainEvent.ImageUrl);
        }
    }
}
