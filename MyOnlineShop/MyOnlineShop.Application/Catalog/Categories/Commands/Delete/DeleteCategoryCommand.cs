namespace MyOnlineShop.Application.Catalog.Categories.Commands.Delete
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class DeleteCategoryCommand : IRequest<Result>
    {
        public DeleteCategoryCommand()
        {
        }

        public DeleteCategoryCommand(
            int id,
            string name,
            string imageUrl)
            : this()
        {
            this.Id = id;
            this.Name = name;
            this.ImageUrl = imageUrl;
        }

        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;
    }
}
