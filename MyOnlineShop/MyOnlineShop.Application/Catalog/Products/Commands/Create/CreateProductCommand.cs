namespace MyOnlineShop.Application.Catalog.Products.Commands.Create
{
    using MediatR;
    using MyOnlineShop.Application.Catalog.Products.Commands.Common;
    using MyOnlineShop.Application.Common;

    public class CreateProductCommand : ProductCommand, IRequest<Result<int>>
    {
    }
}
