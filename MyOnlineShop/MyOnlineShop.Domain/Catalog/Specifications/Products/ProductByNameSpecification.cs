namespace MyOnlineShop.Domain.Catalog.Specifications.Products
{
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class ProductByNameSpecification : Specification<Product>
    {
        private readonly string? name;

        public ProductByNameSpecification(string? name)
        {
            this.name = name;
        }

        protected override bool Include => this.name != null;

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.Name.Contains(this.name!);
        }
    }
}
