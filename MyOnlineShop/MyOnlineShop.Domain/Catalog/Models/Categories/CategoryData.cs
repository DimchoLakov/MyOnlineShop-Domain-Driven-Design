namespace MyOnlineShop.Domain.Catalog.Models.Categories
{
    using MyOnlineShop.Domain.Common;
    using System;
    using System.Collections.Generic;

    public class CategoryData : IInitialData
    {
        public Type EntityType => typeof(Category);

        public IEnumerable<object> GetData()
        {
            return new List<Category>
            {
               new Category(
                   name: "Computing",
                   imageUrl: "https://unsplash.com/photos/CANL3bzp6wU",
                   order: 1,
                   isActive: true),

               new Category(
                   name: "Cars",
                   imageUrl: "https://unsplash.com/photos/3ZUsNJhi_Ik",
                   order: 2,
                   isActive: true),

               new Category(
                   name: "Phones",
                   imageUrl: "https://unsplash.com/photos/2JrpkyZ2ruQ",
                   order: 3,
                   isActive: true),

               new Category(
                   name: "Smart Tech",
                   imageUrl: "https://unsplash.com/photos/Im7lZjxeLhg",
                   order: 4,
                   isActive: true),

               new Category(
                   name: "Gaming",
                   imageUrl: "https://unsplash.com/photos/m3hn2Kn5Bns",
                   order: 5,
                   isActive: true),

               new Category(
                   name: "Luxury",
                   imageUrl: "https://unsplash.com/photos/FD0Ga_KJTwM",
                   order: 6,
                   isActive: true)
            };
        }
    }
}
