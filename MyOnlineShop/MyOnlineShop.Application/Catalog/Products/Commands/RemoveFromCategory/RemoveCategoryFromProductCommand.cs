namespace MyOnlineShop.Application.Catalog.Products.Commands.RemoveFromCategory
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class RemoveCategoryFromProductCommand : IRequest<Result>
    {
        public RemoveCategoryFromProductCommand(
            int productId,
            int categoryId)
        {
            this.ProductId = productId;
            this.CategoryId = categoryId;
        }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }
    }
}
