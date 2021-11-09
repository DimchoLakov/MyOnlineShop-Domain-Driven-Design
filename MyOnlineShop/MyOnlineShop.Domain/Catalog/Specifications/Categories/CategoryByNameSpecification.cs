namespace MyOnlineShop.Domain.Catalog.Specifications.Categories
{
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using MyOnlineShop.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class CategoryByNameSpecification : Specification<Category>
    {
        private readonly string? name;

        public CategoryByNameSpecification(string name)
        {
            this.name = name;
        }

        protected override bool Include => this.name != null;

        public override Expression<Func<Category, bool>> ToExpression()
        {
            return category => category.Name.Contains(this.name!);
        }
    }
}
