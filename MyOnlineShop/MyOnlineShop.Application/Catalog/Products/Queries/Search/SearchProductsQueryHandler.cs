namespace MyOnlineShop.Application.Catalog.Products.Queries.Search
{
    using MediatR;
    using MyOnlineShop.Application.Catalog.Products.Queries.Common;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Catalog.Specifications.Products;
    using MyOnlineShop.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, SearchProductsOutputModel>
    {
        private const int ProductsPerPage = 10;

        private readonly IProductQueryRepository productQueryRepository;
        private readonly ICurrentUser currentUser;

        public SearchProductsQueryHandler(
            IProductQueryRepository productQueryRepository, 
            ICurrentUser currentUser)
        {
            this.productQueryRepository = productQueryRepository;
            this.currentUser = currentUser;
        }

        public async Task<SearchProductsOutputModel> Handle(
            SearchProductsQuery request,
            CancellationToken cancellationToken)
        {
            var productSpecification = this.GetProductSpecification(request);

            int skip = (request.Page - 1) * ProductsPerPage;

            bool isUserAdmin = this.currentUser.IsAdministrator;

            var productListing = await this.productQueryRepository
                .GetProductListing<ProductOutputModel>(
                    productSpecification,
                    isUserAdmin,
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
