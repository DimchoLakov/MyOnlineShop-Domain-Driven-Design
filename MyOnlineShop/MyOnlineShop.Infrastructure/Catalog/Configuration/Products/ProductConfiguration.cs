namespace MyOnlineShop.Infrastructure.Catalog.Configuration.Products
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common.Models;
    using static MyOnlineShop.Domain.Catalog.Models.ModelConstants.Product;
    using static MyOnlineShop.Domain.Common.Constants.Common;

    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(NameMaxLength)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(DescriptionMaxLength)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            builder
                .Property(p => p.Code)
                .HasMaxLength(MaxCodeLength)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(p => p.ImageUrl)
                .HasMaxLength(MaxUrlLength)
                .IsRequired();

            var productTypeConverter = new ValueConverter<ProductType, int>(
                v => v.Value,
                v => Enumeration.FromValue<ProductType>(v));

            builder
                .Property(p => p.Type)
                .HasConversion(productTypeConverter);

            builder
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(p => p.ToTable("ProductCategories"));

            builder
                .HasMany(p => p.Options)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("options");
        }
    }
}
