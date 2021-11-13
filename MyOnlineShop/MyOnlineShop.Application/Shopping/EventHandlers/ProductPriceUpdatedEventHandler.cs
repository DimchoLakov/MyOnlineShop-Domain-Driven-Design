namespace MyOnlineShop.Application.Shopping.EventHandlers
{
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Domain.Catalog.Events;
    using MyOnlineShop.Domain.Shopping.Repositories;
    using System.Threading.Tasks;

    public class ProductPriceUpdatedEventHandler : IEventHandler<ProductPriceUpdatedEvent>
    {
        private readonly IShoppingCartDomainRepository shoppingCartDomainRepository;

        public ProductPriceUpdatedEventHandler(IShoppingCartDomainRepository shoppingCartDomainRepository)
        {
            this.shoppingCartDomainRepository = shoppingCartDomainRepository;
        }

        public async Task Handle(ProductPriceUpdatedEvent domainEvent)
        {
            await this.shoppingCartDomainRepository
                      .UpdateCartItemsWithProductPrice(domainEvent.ProductId, domainEvent.ProductPrice);
        }
    }
}
