namespace MyOnlineShop.Application.Catalog.Categories.Queries.All
{
    using MyOnlineShop.Application.Common.Mapping;
    using MyOnlineShop.Domain.Catalog.Models.Categories;

    public class CategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public int Order { get; private set; }

        public bool IsActive { get; private set; }
    }
}
