namespace MyOnlineShop.Application.Catalog.Products.Queries.Details
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class ProductDetailsQuery : EntityCommand<int>, IRequest<ProductDetailsOutputModel>
    {
    }
}
