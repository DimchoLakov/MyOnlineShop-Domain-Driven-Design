namespace MyOnlineShop.Application.Shopping.EventHandlers
{
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Domain.Catalog.Events;
    using MyOnlineShop.Domain.Shopping.Repositories;
    using System.Threading.Tasks;

    public class ProductDescriptionUpdatedEventHandler : IEventHandler<ProductDescriptionUpdatedEvent>
    {
        private readonly IShoppingCartDomainRepository shoppingCartDomainRepository;

        public ProductDescriptionUpdatedEventHandler(IShoppingCartDomainRepository shoppingCartDomainRepository)
        {
            this.shoppingCartDomainRepository = shoppingCartDomainRepository;
        }

        public async Task Handle(ProductDescriptionUpdatedEvent domainEvent)
        {
            await this.shoppingCartDomainRepository
                      .UpdateCartItemsWithProductName(domainEvent.ProductId, domainEvent.ProductDescription);
        }
    }
}
