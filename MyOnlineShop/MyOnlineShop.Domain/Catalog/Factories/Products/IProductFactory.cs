namespace MyOnlineShop.Domain.Catalog.Factories.Products
{
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;

    public interface IProductFactory : IFactory<Product>
    {
        IProductFactory WithName(string name);

        IProductFactory WithDescription(string description);

        IProductFactory WithPrice(decimal price);

        IProductFactory WithWeight(double weight);

        IProductFactory WithCode(string code);

        IProductFactory WithImageUrl(string imageUrl);

        IProductFactory WithStockAvailable(int stockAvailable);

        IProductFactory WithMaxStock(int maxStock);

        IProductFactory WithIsOnSale(bool isOnSale);

        IProductFactory WithIsArchived(bool isArchived);

        IProductFactory WithType(ProductType type);
    }
}
    