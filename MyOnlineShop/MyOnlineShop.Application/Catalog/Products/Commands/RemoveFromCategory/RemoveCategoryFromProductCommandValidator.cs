namespace MyOnlineShop.Application.Catalog.Products.Commands.RemoveFromCategory
{
    using FluentValidation;

    public class RemoveCategoryFromProductCommandValidator : AbstractValidator<RemoveCategoryFromProductCommand>
    {
        public RemoveCategoryFromProductCommandValidator()
        {
            this.RuleFor(r => r.CategoryId)
                .Must(categoryId => categoryId != 0);

            this.RuleFor(r => r.ProductId)
                .Must(productId => productId != 0);
        }
    }
}
