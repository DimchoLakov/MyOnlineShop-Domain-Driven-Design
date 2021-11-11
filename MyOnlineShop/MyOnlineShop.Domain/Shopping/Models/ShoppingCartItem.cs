namespace MyOnlineShop.Domain.Shopping.Models
{
    using MyOnlineShop.Domain.Common.Models;
    using MyOnlineShop.Domain.Shopping.Exceptions;

    public class ShoppingCartItem : Entity<int>
    {
        internal ShoppingCartItem(
            int productId,
            int quantity,
            string productName,
            double productWeight,
            decimal productPrice,
            string productDescription,
            string productImageUrl)
        {
            this.Validate(
                productId,
                quantity,
                productName,
                productWeight,
                productPrice,
                productDescription,
                productImageUrl);

            this.ProductId = productId;
            this.Quantity = quantity;
            this.ProductName = productName;
            this.ProductWeight = productWeight;
            this.ProductPrice = productPrice;
            this.ProductDescription = productDescription;
            this.ProductImageUrl = productImageUrl;
        }

        public int ProductId { get; private set; }

        public int Quantity { get; private set; }

        public string ProductName { get; private set; }

        public double ProductWeight { get; private set; }

        public decimal ProductPrice { get; private set; }

        public string ProductDescription { get; private set; }

        public string ProductImageUrl { get; private set; }

        public decimal Price => this.ProductPrice * this.Quantity;

        private void Validate(
            int productId,
            int quantity,
            string productName,
            double productWeight,
            decimal productPrice,
            string productDescription,
            string productImageUrl)
        {
            this.ValidateProductId(productId);
            this.ValidateQuantity(quantity);
            this.ValidateProductName(productName);
            this.ValidateProductWeight(productWeight);
            this.ValidateProductPrice(productPrice);
            this.ValidateProductDescription(productDescription);
            this.ValidateProductImageUrl(productImageUrl);
        }

        private void ValidateProductId(int productId)
        {
            Guard.AgainstOutOfRange<InvalidShoppingCartItemException>(productId, 1, int.MaxValue, nameof(this.ProductId));
        }

        private void ValidateQuantity(int quantity)
        {
            Guard.AgainstOutOfRange<InvalidShoppingCartItemException>(quantity, 1, int.MaxValue, nameof(this.Quantity));
        }

        private void ValidateProductName(string productName)
        {
            Guard.ForStringLength<InvalidShoppingCartItemException>(
                productName, 
                ModelConstants.ShoppingCartItem.ProductNameMinLength, 
                ModelConstants.ShoppingCartItem.ProductNameMaxLength, 
                nameof(this.ProductName));
        }

        private void ValidateProductWeight(double productWeight)
        {
            Guard.AgainstOutOfRange<InvalidShoppingCartItemException>(
                productWeight, 
                ModelConstants.ShoppingCartItem.MinProductWeight, 
                ModelConstants.ShoppingCartItem.MaxProductWeight, 
                nameof(this.ProductWeight));
        }

        private void ValidateProductPrice(decimal productPrice)
        {
            Guard.AgainstOutOfRange<InvalidShoppingCartItemException>(
                productPrice, 
                ModelConstants.ShoppingCartItem.MinProductPrice, 
                ModelConstants.ShoppingCartItem.MaxProductPrice, 
                nameof(this.ProductPrice));
        }

        private void ValidateProductDescription(string productDescription)
        {
            Guard.ForStringLength<InvalidShoppingCartItemException>(
                productDescription, 
                ModelConstants.ShoppingCartItem.ProductDescriptionMinLength, 
                ModelConstants.ShoppingCartItem.ProductDescriptionMaxLength, 
                nameof(this.ProductDescription));
        }

        private void ValidateProductImageUrl(string productImageUrl)
        {
            Guard.ForValidUrl<InvalidShoppingCartItemException>(productImageUrl, nameof(this.ProductImageUrl));
        }
    }
}
