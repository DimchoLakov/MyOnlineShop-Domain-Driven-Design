namespace MyOnlineShop.Application.Catalog.Products.Commands.Edit
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Domain.Catalog.Factories.Products;
    using MyOnlineShop.Domain.Catalog.Repositories.Products;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Result<bool>>
    {
        private readonly IProductFactory productFactory;
        private readonly IProductDomainRepository productDomainRepository;

        public EditProductCommandHandler(
            IProductFactory productFactory, 
            IProductDomainRepository productDomainRepository)
        {
            this.productFactory = productFactory;
            this.productDomainRepository = productDomainRepository;
        }

        public async Task<Result<bool>> Handle(
            EditProductCommand request, 
            CancellationToken cancellationToken)
        {
            var product = await this.productDomainRepository.Find(request.Id, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException(nameof(product), request.Id);
            }

            product
                .UpdateName(request.Name)
                .UpdateDescription(request.Description)
                .UpdateCode(request.Code)
                .UpdateImageUrl(request.ImageUrl)
                .UpdateIsArchived(request.IsArchived)
                .UpdateIsOnSale(request.IsOnSale)
                .UpdateMaxStock(request.MaxStock)
                .UpdatePrice(request.Price)
                .UpdateStockAvailable(request.StockAvailable)
                .UpdateType(request.Type)
                .UpdateWeight(request.Weight);

            await this.productDomainRepository.SaveAsync(product, cancellationToken);

            return true;
        }
    }
}
