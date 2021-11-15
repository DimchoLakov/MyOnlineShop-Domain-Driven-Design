namespace MyOnlineShop.Domain.Ordering.Models.Orders
{
    using MyOnlineShop.Domain.Common.Models;
    using MyOnlineShop.Domain.Ordering.Exceptions;

    public class OrderItem : Entity<int>
    {
        internal OrderItem(
            int productId,
            string name,
            string description,
            decimal productPrice,
            int quantity,
            string imageUrl)
        {
            this.Validate(
                name,
                description,
                productPrice,
                quantity,
                imageUrl);

            this.ProductId = productId;
            this.Name = name;
            this.Description = description;
            this.ProductPrice = productPrice;
            this.Quantity = quantity;
            this.ImageUrl = imageUrl;
        }

        public int ProductId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal ProductPrice { get; private set; }

        public int Quantity { get; private set; }

        public string ImageUrl { get; private set; }

        public decimal Price => this.ProductPrice * this.Quantity;

        private void Validate(
            string name,
            string description,
            decimal productPrice,
            int quantity,
            string imageurl)
        {
            this.ValidateName(name);
            this.ValidateDescription(description);
            this.ValidateProductPrice(productPrice);
            this.ValidateQuantity(quantity);
            this.ValidateImageUrl(imageurl);
        }

        private void ValidateQuantity(int quantity)
        {
            Guard.AgainstOutOfRange<InvalidOrderItemException>(
                quantity,
                ModelConstants.OrderItem.MinQuantity,
                ModelConstants.OrderItem.MaxQuantity,
                nameof(this.Quantity));
        }

        private void ValidateName(string name)
        {
            Guard.ForStringLength<InvalidOrderItemException>(
                name,
                ModelConstants.OrderItem.NameMinLength,
                ModelConstants.OrderItem.NameMaxLength,
                nameof(this.Name));
        }

        private void ValidateProductPrice(decimal productPrice)
        {
            Guard.AgainstOutOfRange<InvalidOrderItemException>(
                productPrice,
                ModelConstants.OrderItem.MinProductPrice,
                ModelConstants.OrderItem.MaxProductPrice,
                nameof(this.ProductPrice));
        }

        private void ValidateDescription(string description)
        {
            Guard.ForStringLength<InvalidOrderItemException>(
                description,
                ModelConstants.OrderItem.DescriptionMinLength,
                ModelConstants.OrderItem.DescriptionMaxLength,
                nameof(this.Description));
        }

        private void ValidateImageUrl(string imageUrl)
        {
            Guard.ForValidUrl<InvalidOrderItemException>(imageUrl, nameof(this.ImageUrl));
        }
    }
}
