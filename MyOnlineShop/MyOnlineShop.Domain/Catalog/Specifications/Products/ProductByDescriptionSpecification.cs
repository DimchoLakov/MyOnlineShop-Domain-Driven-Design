namespace MyOnlineShop.Domain.Catalog.Specifications.Products
{
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class ProductByDescriptionSpecification : Specification<Product>
    {
        private readonly string? description;

        public ProductByDescriptionSpecification(string? description)
        {
            this.description = description;
        }

        protected override bool Include => this.description != null;

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.Description.Contains(this.description!);
        }
    }
}
