namespace MyOnlineShop.Application.Catalog.Products.Queries.Search
{
    using MyOnlineShop.Application.Catalog.Products.Queries.Common;
    using System.Collections.Generic;

    public class SearchProductsOutputModel : ProductsOutputModel<ProductOutputModel>
    {
        public SearchProductsOutputModel(
            List<ProductOutputModel> products,
            int page,
            int totalPages)
            : base(products, page, totalPages)
        {
        }
    }
}
