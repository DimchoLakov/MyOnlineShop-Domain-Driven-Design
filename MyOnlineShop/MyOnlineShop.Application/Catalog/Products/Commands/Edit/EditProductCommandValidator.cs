namespace MyOnlineShop.Application.Catalog.Products.Commands.Edit
{
    using FluentValidation;
    using MyOnlineShop.Application.Catalog.Products.Commands.Common;

    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            this.Include(new ProductCommandValidator());
        }
    }
}
