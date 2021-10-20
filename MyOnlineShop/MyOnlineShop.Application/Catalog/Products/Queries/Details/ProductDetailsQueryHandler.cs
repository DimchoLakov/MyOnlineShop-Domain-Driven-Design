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

        public Task<ProductDetailsOutputModel> Handle(
            ProductDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var productDetails = this.productQueryRepository.GetDetails(request.Id, cancellationToken);

            return productDetails;
        }
    }
}
