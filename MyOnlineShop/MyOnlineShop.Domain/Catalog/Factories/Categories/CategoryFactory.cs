namespace MyOnlineShop.Domain.Catalog.Factories.Categories
{
    using MyOnlineShop.Domain.Catalog.Exceptions.Categories;
    using MyOnlineShop.Domain.Catalog.Models.Categories;

    public class CategoryFactory : ICategoryFactory
    {
        private string name = default!;
        private string imageUrl = default!;
        private int order = default;
        private bool isActive = true; // default is true

        bool isNameSet = false;
        bool isImageUrlSet = false;
        bool isOrderSet = false;

        public ICategoryFactory WithName(string name)
        {
            this.name = name;
            this.isNameSet = true;

            return this;
        }

        public ICategoryFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;
            this.isImageUrlSet = true;

            return this;
        }

        public ICategoryFactory WithOrder(int order)
        {
            this.order = order;
            this.isOrderSet = true;

            return this;
        }

        public ICategoryFactory WithIsActive(bool isActive)
        {
            this.isActive = isActive;

            return this;
        }

        public Category Build()
        {
            if (!this.isNameSet || 
                !this.isImageUrlSet || 
                !this.isOrderSet)
            {
                throw new InvalidCategoryException("Name, Image Url and Order must be set!");
            }

            return new Category(this.name, this.imageUrl, this.order, this.isActive);
        }
    }
}
