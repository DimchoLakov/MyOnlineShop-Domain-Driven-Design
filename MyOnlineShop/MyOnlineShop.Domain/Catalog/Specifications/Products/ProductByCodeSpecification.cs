namespace MyOnlineShop.Domain.Catalog.Specifications.Products
{
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class ProductByCodeSpecification : Specification<Product>
    {
        private readonly string? code;

        public ProductByCodeSpecification(string? name)
        {
            this.code = name;
        }

        protected override bool Include => this.code != null;

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.Code == this.code;
        }
    }
}
