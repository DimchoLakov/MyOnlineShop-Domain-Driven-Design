namespace MyOnlineShop.Infrastructure.Catalog.Configuration.Products
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using static MyOnlineShop.Domain.Catalog.Models.ModelConstants.ProductOption;

    public class ProductOptionConfiguration : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Name)
                .HasMaxLength(NameMaxLength)
                .IsUnicode()
                .IsRequired();
        }
    }
}
