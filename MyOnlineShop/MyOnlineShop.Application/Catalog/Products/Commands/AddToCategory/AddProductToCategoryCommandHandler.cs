namespace MyOnlineShop.Application.Catalog.Products.Commands.AddToCategory
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Domain.Catalog.Repositories.Categories;
    using MyOnlineShop.Domain.Catalog.Repositories.Products;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddProductToCategoryCommandHandler : IRequestHandler<AddProductToCategoryCommand, Result>
    {
        private readonly IProductDomainRepository productDomainRepository;
        private readonly ICategoryDomainRepository categoryDomainRepository;

        public AddProductToCategoryCommandHandler(
            IProductDomainRepository productDomainRepository, 
            ICategoryDomainRepository categoryDomainRepository)
        {
            this.productDomainRepository = productDomainRepository;
            this.categoryDomainRepository = categoryDomainRepository;
        }

        public async Task<Result> Handle(
            AddProductToCategoryCommand request, 
            CancellationToken cancellationToken)
        {
            var product = await this.productDomainRepository.Find(request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException(nameof(product), request.ProductId);
            }

            var category = await this.categoryDomainRepository.Find(request.CategoryId, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException(nameof(category), request.CategoryId);
            }

            product.AddCategory(category);

            await this.productDomainRepository.SaveAsync(product, cancellationToken);

            return Result.Success;
        }
    }
}
