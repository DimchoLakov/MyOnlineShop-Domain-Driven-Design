namespace MyOnlineShop.Domain.Catalog.Models.Products
{
    using MyOnlineShop.Domain.Common;
    using System;
    using System.Collections.Generic;

    public class ProductData : IInitialData
    {
        public Type EntityType => typeof(Product);

        public IEnumerable<object> GetData()
        {
            return new List<Product>
            {
                new Product(
                    name: "Lamborghini Aventador",
                    description: "Automobili Lamborghini S.p.A. is an Italian brand and manufacturer of luxury sports cars and SUVs based in Sant\'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.",
                    price: 200_000,
                    imageUrl: "https://images.unsplash.com/photo-1526550517342-e086b387edda?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=801&q=80",
                    weight: 1300,
                    code: "code1111",
                    stockAvailable: 5,
                    maxStock: 10,
                    type: ProductType.Vehicles,
                    isOnSale: false,
                    isArchived: false)
                .AddOption(name: "Wireless Phone Charger", price: 200),

                new Product(
                    name: "ROG Mothership",
                    description: "ROG Mothership is a portable Windows 10 Pro powerhouse with an innovative standing design that enhances cooling for its factory overclocked GeForce RTX™ 2080 GPU and 9th Gen Intel® Core™ i9 eight-core CPU.",
                    price: 3_000,
                    imageUrl: "https://images.unsplash.com/photo-1555680202-c86f0e12f086?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80",
                    weight: 3,
                    code: "code1112",
                    stockAvailable: 10,
                    maxStock: 20,
                    type: ProductType.Electronics,
                    isOnSale: false,
                    isArchived: false)
                .AddOption(name: "CD", price: 120),

                new Product(
                    name: "Samsung S20",
                    description: "The new Galaxy S20 is made for the powerful camera. We've created more memory for your memories, with up to a massive 128GB of internal storage on the Galaxy S20 to keep all your high-res videos and photos.",
                    price: 1_200,
                    imageUrl: "https://images.unsplash.com/photo-1583573636255-6a41ff5523d4?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1495&q=80",
                    weight: 1300,
                    code: "code1113",
                    stockAvailable: 10,
                    maxStock: 15,
                    type: ProductType.Electronics,
                    isOnSale: false,
                    isArchived: false)
                .AddOption(name: "Extra memory", price: 150),

                new Product(
                    name: "Nike AirMax 120",
                    description: "Nike, Inc. is an American multinational corporation that is engaged in the design, development, manufacturing, and worldwide marketing and sales of footwear, apparel, equipment, accessories, and services.",
                    price: 120,
                    imageUrl: "https://images.unsplash.com/photo-1557178416-e694c669c944?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1351&q=80",
                    weight: 0.3,
                    code: "code1114",
                    stockAvailable: 30,
                    maxStock: 50,
                    type: ProductType.Fashion,
                    isOnSale: false,
                    isArchived: false)
                .AddOption(name: "Extra ties", price: 10),

                new Product(
                    name: "Rolex",
                    description: "Rolex watches are crafted from the finest raw materials and assembled with scrupulous attention to detail.",
                    price: 10_000,
                    imageUrl: "https://images.unsplash.com/photo-1587836374828-4dbafa94cf0e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80",
                    weight: 0.1,
                    code: "code1115",
                    stockAvailable: 3,
                    maxStock: 25,
                    type: ProductType.Fashion,
                    isOnSale: false,
                    isArchived: false)
                .AddOption(name: "Rolex Case", price: 500)
            };
        }
    }
}
