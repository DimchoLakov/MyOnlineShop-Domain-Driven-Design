namespace MyOnlineShop.Application.Catalog.Products.Commands.Common
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductCommand
    {
        public ProductCommand()
        {
            this.ProductTypeSelectListItems = Enumeration
                .GetAll<ProductType>()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Value.ToString()
                });
        }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string Code { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public int StockAvailable { get; set; }

        public int MaxStock { get; set; }

        public bool IsOnSale { get; set; }

        public bool IsArchived { get; set; }

        public int Type { get; set; }
        public IEnumerable<SelectListItem> ProductTypeSelectListItems { get; set; } = new List<SelectListItem>();
    }
}
