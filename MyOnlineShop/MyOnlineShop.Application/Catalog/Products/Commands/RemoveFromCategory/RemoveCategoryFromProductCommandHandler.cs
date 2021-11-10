namespace MyOnlineShop.Application.Catalog.Products.Commands.RemoveFromCategory
{
    using MediatR;
    using MyOnlineShop.Application.Catalog.Categories;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Domain.Catalog.Repositories.Categories;
    using MyOnlineShop.Domain.Catalog.Repositories.Products;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveCategoryFromProductCommandHandler : IRequestHandler<RemoveCategoryFromProductCommand, Result>
    {
        private readonly IProductDomainRepository productDomainRepository;
        private readonly ICategoryDomainRepository categoryDomainRepository;

        public RemoveCategoryFromProductCommandHandler(
            IProductDomainRepository productDomainRepository,
            ICategoryDomainRepository categoryDomainRepository)
        {
            this.productDomainRepository = productDomainRepository;
            this.categoryDomainRepository = categoryDomainRepository;
        }

        public async Task<Result> Handle(
            RemoveCategoryFromProductCommand request, 
            CancellationToken cancellationToken)
        {
            var product = await this.productDomainRepository.FindWithCategories(request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException(nameof(product), request.ProductId);
            }

            var category = await this.categoryDomainRepository.Find(request.CategoryId, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException(nameof(category), request.CategoryId);
            }

            product.RemoveCategory(category);

            await this.productDomainRepository.SaveAsync(product, cancellationToken);

            return Result.Success;
        }
    }
}
