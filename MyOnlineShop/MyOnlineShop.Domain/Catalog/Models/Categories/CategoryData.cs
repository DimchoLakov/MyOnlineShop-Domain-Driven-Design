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
                   imageUrl: "https://www.port.ac.uk/-/media/images/heros---1200x400-large---640x400-small/courses/courses/ug-courses/computing_800x400.jpg",
                   order: 1,
                   isActive: true),

               new Category(
                   name: "Cars",
                   imageUrl: "https://media.gq-magazine.co.uk/photos/5fdcb8470d9a429c2d245628/master/pass/2021CARS_AUDIEtron.jpg",
                   order: 2,
                   isActive: true),

               new Category(
                   name: "Phones",
                   imageUrl: "https://www.cnet.com/a/img/iJxo9AIxiXHqVoqm6nGISKtKwPI=/2020/08/18/b7168aea-9f7e-47bb-9f31-4cb8ad92fbc7/lg-note-20-ultra-5g-iphone-11-se-google-pixel-4a-lg-velvet-6133.jpg",
                   order: 3,
                   isActive: true),

               new Category(
                   name: "Smart Tech",
                   imageUrl: "https://www.build-review.com/wp-content/uploads/2020/06/smart-home-tech-1920-x-1080.jpg",
                   order: 4,
                   isActive: true),

               new Category(
                   name: "Gaming",
                   imageUrl: "https://assets.entrepreneur.com/content/3x2/2000/1603915291-Gamers.jpg",
                   order: 5,
                   isActive: true),

               new Category(
                   name: "Luxury",
                   imageUrl: "https://www.iexpats.com/wp-content/uploads/2016/12/luxury-home.jpg",
                   order: 6,
                   isActive: true)
            };
        }
    }
}
