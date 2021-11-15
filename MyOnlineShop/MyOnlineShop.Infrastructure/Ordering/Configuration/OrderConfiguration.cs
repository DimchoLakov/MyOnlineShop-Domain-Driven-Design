namespace MyOnlineShop.Infrastructure.Ordering.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using MyOnlineShop.Domain.Common.Models;
    using MyOnlineShop.Domain.Ordering.Models.Orders;

    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.UserId)
                .IsRequired();

            var orderStatusConverter = new ValueConverter<OrderStatus, int>(
                v => v.Value,
                v => Enumeration.FromValue<OrderStatus>(v));

            builder
                .Property(o => o.OrderStatus)
                .HasConversion(orderStatusConverter);

            builder
                .OwnsOne(o => o.Address)
                .WithOwner();

            builder
                .HasMany(o => o.OrderItems)
                .WithOne();
        }
    }
}
