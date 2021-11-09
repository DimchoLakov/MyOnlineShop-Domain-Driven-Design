namespace MyOnlineShop.Application.Catalog.Categories.Commands.Create
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class CreateCategoryCommand : IRequest<Result<int>>
    {
        public string Name { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public bool IsActive { get; private set; } = true;
    }
}
