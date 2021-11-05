namespace MyOnlineShop.Application.Catalog.Products.Commands.Create
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Domain.Catalog.Factories.Products;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Catalog.Repositories.Products;
    using MyOnlineShop.Domain.Common.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
    {
        private readonly IProductFactory productFactory;
        private readonly IProductDomainRepository productDomainRepository;

        public CreateProductCommandHandler(
            IProductFactory productFactory, 
            IProductDomainRepository productDomainRepository)
        {
            this.productFactory = productFactory;
            this.productDomainRepository = productDomainRepository;
        }

        public async Task<Result<int>> Handle(
            CreateProductCommand request, 
            CancellationToken cancellationToken)
        {
            var productType = Enumeration.FromValue<ProductType>(request.Type);

            var product = this.productFactory
                .WithName(request.Name)
                .WithDescription(request.Description)
                .WithPrice(request.Price)
                .WithWeight(request.Weight)
                .WithCode(request.Code)
                .WithImageUrl(request.ImageUrl)
                .WithStockAvailable(request.StockAvailable)
                .WithMaxStock(request.MaxStock)
                .WithIsOnSale(request.IsOnSale)
                .WithIsArchived(request.IsArchived)
                .WithType(productType)
                .Build();

            await this.productDomainRepository.SaveAsync(product, cancellationToken);

            return Result<int>.SuccessWith(product.Id);
        }
    }
}
