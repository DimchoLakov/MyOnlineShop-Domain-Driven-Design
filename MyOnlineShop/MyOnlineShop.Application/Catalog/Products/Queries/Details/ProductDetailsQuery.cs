namespace MyOnlineShop.Application.Catalog.Products.Queries.Details
{
    using MediatR;

    public class ProductDetailsQuery : IRequest<ProductDetailsOutputModel>
    {
        public ProductDetailsQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}
