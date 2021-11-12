namespace MyOnlineShop.Infrastructure.Shopping.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyOnlineShop.Domain.Shopping.Models;

    internal class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.UniqueId)
                .IsRequired();

            builder
                .Property(s => s.UserId)
                .IsRequired();

            builder
                .HasMany(s => s.CartItems)
                .WithOne()
                .HasForeignKey("ShoppingCartId");
        }
    }
}
