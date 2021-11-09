namespace MyOnlineShop.Application.Catalog.Categories.Commands.Create
{
    using FluentValidation;
    using MyOnlineShop.Domain.Catalog.Models;
    using MyOnlineShop.Domain.Common;

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator(ICategoryQueryRepository categoryQueryRepository)
        {
            this.RuleFor(c => c.Name)
                .MinimumLength(ModelConstants.Category.NameMinLength)
                .MaximumLength(ModelConstants.Category.NameMaxLength)
                .NotEmpty()
                .MustAsync(async (categoryName, token) => await categoryQueryRepository.Exists(categoryName, token) == false)
                .WithMessage("Category with {PropertyName} - '{PropertyValue}' already exists!");

            this.RuleFor(c => c.ImageUrl)
                .MaximumLength(Constants.Common.MaxUrlLength)
                .NotEmpty();
        }
    }
}
