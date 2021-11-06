namespace MyOnlineShop.Application.Catalog.Products.Commands.Common
{
    using FluentValidation;
    using MyOnlineShop.Domain.Catalog.Models;
    using MyOnlineShop.Domain.Common;

    public class ProductCommandValidator : AbstractValidator<ProductCommand>
    {
        public ProductCommandValidator()
        {
            this.RuleFor(p => p.Name)
                .MinimumLength(ModelConstants.Product.NameMinLength)
                .MaximumLength(ModelConstants.Product.NameMaxLength)
                .NotEmpty();

            this.RuleFor(p => p.Description)
                .MinimumLength(ModelConstants.Product.DescriptionMinLength)
                .MaximumLength(ModelConstants.Product.DescriptionMaxLength)
                .NotEmpty();

            this.RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(ModelConstants.Product.MinPrice)
                .LessThanOrEqualTo(ModelConstants.Product.MaxPrice);

            this.RuleFor(p => p.Weight)
                .GreaterThanOrEqualTo(ModelConstants.Product.MinWeight)
                .LessThanOrEqualTo(ModelConstants.Product.MaxWeight);

            this.RuleFor(p => p.Code)
                .MinimumLength(ModelConstants.Product.MinCodeLength)
                .MaximumLength(ModelConstants.Product.MaxCodeLength)
                .NotEmpty();

            this.RuleFor(p => p.ImageUrl)
                .MaximumLength(Constants.Common.MaxUrlLength)
                .NotEmpty();

            this.RuleFor(p => p.StockAvailable)
                .GreaterThanOrEqualTo(ModelConstants.Product.MinStockAvailable)
                .LessThanOrEqualTo(ModelConstants.Product.MaxStockAvailable);

            this.RuleFor(p => p.MaxStock)
                .GreaterThanOrEqualTo(ModelConstants.Product.MinStock)
                .LessThanOrEqualTo(ModelConstants.Product.MaxStock);

            this.RuleFor(p => p.Type)
                .GreaterThanOrEqualTo(ModelConstants.Product.MinProductType)
                .LessThanOrEqualTo(ModelConstants.Product.MaxProductType)
                .NotNull();
        }
    }
}
