namespace MyOnlineShop.Domain.Catalog.Factories.Categories
{
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using MyOnlineShop.Domain.Common;

    public interface ICategoryFactory : IFactory<Category>
    {
        ICategoryFactory WithName(string name);

        ICategoryFactory WithImageUrl(string imageUrl);

        ICategoryFactory WithOrder(int order);

        ICategoryFactory WithIsActive(bool isActive);
    }
}
