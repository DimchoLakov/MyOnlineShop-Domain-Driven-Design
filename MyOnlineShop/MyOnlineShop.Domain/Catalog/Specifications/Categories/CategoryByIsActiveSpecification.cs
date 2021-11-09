namespace MyOnlineShop.Domain.Catalog.Specifications.Categories
{
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using MyOnlineShop.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class CategoryByIsActiveSpecification : Specification<Category>
    {
        private readonly bool isActive;

        public CategoryByIsActiveSpecification(bool isActive)
        {
            this.isActive = isActive;
        }

        public override Expression<Func<Category, bool>> ToExpression()
        {
            if (this.isActive)
            {
                return category => category.IsActive;
            }

            return category => true;
        }
    }
}
