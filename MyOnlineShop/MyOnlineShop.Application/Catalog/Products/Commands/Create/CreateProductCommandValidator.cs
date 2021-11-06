namespace MyOnlineShop.Application.Catalog.Products.Commands.Create
{
    using FluentValidation;
    using MyOnlineShop.Application.Catalog.Products.Commands.Common;

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            this.Include(new ProductCommandValidator());
        }
    }
}
