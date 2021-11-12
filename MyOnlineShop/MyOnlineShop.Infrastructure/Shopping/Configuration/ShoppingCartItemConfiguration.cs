namespace MyOnlineShop.Infrastructure.Shopping.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Shopping.Models;

    internal class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Ignore(s => s.Price);

            builder
                .Property(s => s.ProductDescription)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(ModelConstants.ShoppingCartItem.ProductDescriptionMaxLength);

            builder
                .Property(s => s.ProductImageUrl)
                .IsRequired()
                .HasMaxLength(Constants.Common.MaxUrlLength);

            builder
                .Property(s => s.ProductName)
                .IsRequired()
                .HasMaxLength(ModelConstants.ShoppingCartItem.ProductNameMaxLength);

            builder
                .Property(s => s.ProductPrice)
                .HasPrecision(18, 2);
        }
    }
}
