namespace MyOnlineShop.Domain.Catalog.Factories.Products
{
    using MyOnlineShop.Domain.Catalog.Exceptions.Products;
    using MyOnlineShop.Domain.Catalog.Models.Products;

    public class ProductFactory : IProductFactory
    {
        private string name = default!;
        private string description = default!;
        private string code = default!;
        private string imageUrl = default!;
        private int maxStock;
        private decimal price;
        private int stockAvailable;
        private ProductType type = default!;
        private double weight;
        private bool isArchived = false; // default is false
        private bool isOnSale = false; // default is false

        private bool isNameSet = false;
        private bool isDescriptionSet = false;
        private bool isCodeSet = false;
        private bool isImageUrlSet = false;
        private bool isMaxStockSet = false;
        private bool isPriceSet = false;
        private bool isStockAvailableSet = false;
        private bool isTypeSet = false;
        private bool isWeightSet = false;

        public IProductFactory WithCode(string code)
        {
            this.code = code;
            this.isCodeSet = true;

            return this;
        }

        public IProductFactory WithDescription(string description)
        {
            this.description = description;
            this.isDescriptionSet = true;

            return this;
        }

        public IProductFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;
            this.isImageUrlSet = true;

            return this;
        }

        public IProductFactory WithIsArchived(bool isArchived)
        {
            this.isArchived = isArchived;

            return this;
        }

        public IProductFactory WithIsOnSale(bool isOnSale)
        {
            this.isOnSale = isOnSale;

            return this;
        }

        public IProductFactory WithMaxStock(int maxStock)
        {
            this.maxStock = maxStock;
            this.isMaxStockSet = true;

            return this;
        }

        public IProductFactory WithName(string name)
        {
            this.name = name;
            this.isNameSet = true;

            return this;
        }

        public IProductFactory WithPrice(decimal price)
        {
            this.price = price;
            this.isPriceSet = true;

            return this;
        }

        public IProductFactory WithStockAvailable(int stockAvailable)
        {
            this.stockAvailable = stockAvailable;
            this.isStockAvailableSet = true;

            return this;
        }

        public IProductFactory WithType(ProductType type)
        {
            this.type = type;
            this.isTypeSet = true;

            return this;
        }

        public IProductFactory WithWeight(double weight)
        {
            this.weight = weight;
            this.isWeightSet = true;

            return this;
        }

        public Product Build()
        {
            if (!this.isNameSet ||
                !this.isDescriptionSet ||
                !this.isCodeSet ||
                !this.isImageUrlSet ||
                !this.isMaxStockSet ||
                !this.isPriceSet ||
                !this.isStockAvailableSet ||
                !this.isTypeSet ||
                !this.isWeightSet)
            {
                throw new InvalidProductException("Name, Description, Code, Image Url, Max Stock, Price, Stock Available, Type and Weight must be set!");
            }

            return new Product(
                this.name,
                this.description,
                this.price,
                this.weight,
                this.code,
                this.imageUrl,
                this.stockAvailable,
                this.maxStock,
                this.type,
                this.isOnSale,
                this.isArchived);
        }
    }
}
