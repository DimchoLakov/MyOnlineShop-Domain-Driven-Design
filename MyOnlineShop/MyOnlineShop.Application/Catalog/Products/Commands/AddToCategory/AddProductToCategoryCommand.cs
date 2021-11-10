namespace MyOnlineShop.Application.Catalog.Products.Commands.AddToCategory
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class AddProductToCategoryCommand : IRequest<Result>
    {
        public AddProductToCategoryCommand(
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
