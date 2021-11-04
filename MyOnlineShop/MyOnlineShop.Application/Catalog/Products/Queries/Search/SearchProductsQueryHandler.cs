namespace MyOnlineShop.Application.Catalog.Products.Queries.Search
{
    using MediatR;
    using MyOnlineShop.Application.Catalog.Products.Queries.Common;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Catalog.Specifications.Products;
    using MyOnlineShop.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, SearchProductsOutputModel>
    {
        private const int ProductsPerPage = 10;

        private readonly IProductQueryRepository productQueryRepository;

        public SearchProductsQueryHandler(IProductQueryRepository productQueryRepository)
        {
            this.productQueryRepository = productQueryRepository;
        }

        public async Task<SearchProductsOutputModel> Handle(
            SearchProductsQuery request,
            CancellationToken cancellationToken)
        {
            var productSpecification = this.GetProductSpecification(request);

            int skip = (request.Page - 1) * ProductsPerPage;

            var productListing = await this.productQueryRepository
                .GetProductListing<ProductOutputModel>(
                    productSpecification,
                    skip,
                    ProductsPerPage,
                    cancellationToken);

            int totalPages = await this.productQueryRepository
                .GetTotalPages(
                    productSpecification,
                    ProductsPerPage,
                    cancellationToken);

            return new SearchProductsOutputModel(productListing, request.Page, totalPages);
        }

        private Specification<Product> GetProductSpecification(SearchProductsQuery request)
        {
            var productSpecification = new ProductByNameSpecification(request.Name)
                .And(new ProductByCodeSpecification(request.Code))
                .And(new ProductByDescriptionSpecification(request.Description))
                .And(new ProductByMinPriceSpecification(request.MinPrice))
                .And(new ProductByMaxPriceSpecification(request.MaxPrice));

            return productSpecification;
        }
    }
}
