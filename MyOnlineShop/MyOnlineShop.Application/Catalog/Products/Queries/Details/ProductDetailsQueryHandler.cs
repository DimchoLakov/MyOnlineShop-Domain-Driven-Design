namespace MyOnlineShop.Application.Catalog.Products.Queries.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductDetailsQueryHandler : IRequestHandler<ProductDetailsQuery, ProductDetailsOutputModel>
    {
        private readonly IProductQueryRepository productQueryRepository;

        public ProductDetailsQueryHandler(IProductQueryRepository productQueryRepository)
        {
            this.productQueryRepository = productQueryRepository;
        }

        public async Task<ProductDetailsOutputModel> Handle(
            ProductDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var productDetails = await this.productQueryRepository.GetDetails(request.Id, cancellationToken);

            return productDetails;
        }
    }
}
