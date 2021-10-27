namespace MyOnlineShop.Infrastructure.Catalog.Configuration.Categories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using static MyOnlineShop.Domain.Common.Constants.Common;
    using static MyOnlineShop.Domain.Catalog.Models.ModelConstants.Category;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.ImageUrl)
                .HasMaxLength(MaxUrlLength)
                .IsRequired();

            builder
                .Property(c => c.Name)
                .HasMaxLength(NameMaxLength)
                .IsUnicode()
                .IsRequired();
        }
    }
}
