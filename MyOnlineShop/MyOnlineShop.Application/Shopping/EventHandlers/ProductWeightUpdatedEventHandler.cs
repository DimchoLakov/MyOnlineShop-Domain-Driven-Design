namespace MyOnlineShop.Application.Shopping.EventHandlers
{
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Domain.Catalog.Events;
    using MyOnlineShop.Domain.Shopping.Repositories;
    using System.Threading.Tasks;

    public class ProductWeightUpdatedEventHandler : IEventHandler<ProductWeightUpdatedEvent>
    {
        private readonly IShoppingCartDomainRepository shoppingCartDomainRepository;

        public ProductWeightUpdatedEventHandler(IShoppingCartDomainRepository shoppingCartDomainRepository)
        {
            this.shoppingCartDomainRepository = shoppingCartDomainRepository;
        }

        public async Task Handle(ProductWeightUpdatedEvent domainEvent)
        {
            await this.shoppingCartDomainRepository
                      .UpdateCartItemsWithProductWeight(domainEvent.ProductId, domainEvent.ProductWeight);
        }
    }
}
