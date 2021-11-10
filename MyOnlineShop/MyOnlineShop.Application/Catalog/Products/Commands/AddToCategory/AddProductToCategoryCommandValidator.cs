namespace MyOnlineShop.Application.Catalog.Products.Commands.AddToCategory
{
    using FluentValidation;

    public class AddProductToCategoryCommandValidator : AbstractValidator<AddProductToCategoryCommand>
    {
        public AddProductToCategoryCommandValidator()
        {
            this.RuleFor(a => a.CategoryId)
                .Must(categoryId => categoryId != 0);

            this.RuleFor(a => a.ProductId)
                .Must(productId => productId != 0);
        }
    }
}
