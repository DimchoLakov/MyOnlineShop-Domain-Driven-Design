namespace MyOnlineShop.Infrastructure.Ordering.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Ordering.Models;
    using MyOnlineShop.Domain.Ordering.Models.Orders;

    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Description)
                .HasMaxLength(ModelConstants.OrderItem.DescriptionMaxLength)
                .IsRequired();

            builder
                .Property(i => i.ImageUrl)
                .HasMaxLength(Constants.Common.MaxUrlLength)
                .IsRequired();

            builder
                .Property(i => i.Name)
                .HasMaxLength(ModelConstants.OrderItem.NameMaxLength)
                .IsRequired();

            builder
                .Ignore(i => i.Price);

            builder
                .Property(i => i.ProductPrice)
                .HasPrecision(18, 2);
        }
    }
}
