namespace MyOnlineShop.Application.Catalog.Products.Commands.Edit
{
    using MyOnlineShop.Application.Common.Mapping;
    using MyOnlineShop.Domain.Catalog.Models.Categories;

    public class AssignedCategoryModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
