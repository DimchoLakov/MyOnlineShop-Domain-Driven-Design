namespace MyOnlineShop.Application.Shopping.EventHandlers
{
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Domain.Catalog.Events;
    using MyOnlineShop.Domain.Shopping.Repositories;
    using System.Threading.Tasks;

    public class ProductNameUpdatedEventHandler : IEventHandler<ProductNameUpdatedEvent>
    {
        private readonly IShoppingCartDomainRepository shoppingCartDomainRepository;

        public ProductNameUpdatedEventHandler(IShoppingCartDomainRepository shoppingCartDomainRepository)
        {
            this.shoppingCartDomainRepository = shoppingCartDomainRepository;
        }

        public async Task Handle(ProductNameUpdatedEvent domainEvent)
        {
            await this.shoppingCartDomainRepository
                      .UpdateCartItemsWithProductName(domainEvent.ProductId, domainEvent.ProductName);
        }
    }
}
