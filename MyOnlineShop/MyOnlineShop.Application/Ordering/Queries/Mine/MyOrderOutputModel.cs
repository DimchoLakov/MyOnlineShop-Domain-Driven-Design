namespace MyOnlineShop.Application.Ordering.Queries.Mine
{
    using AutoMapper;
    using MyOnlineShop.Application.Common.Mapping;
    using MyOnlineShop.Domain.Ordering.Models.Orders;
    using System;
    using System.Linq;

    public class MyOrderOutputModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderItemsCount { get; set; }

        public decimal TotalPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<Order, MyOrderOutputModel>()
                .ForMember(
                    dest => dest.OrderItemsCount,
                    options => options.MapFrom(
                        src => src.OrderItems.Count))
                .ForMember(dest =>
                    dest.TotalPrice,
                    options => options.MapFrom(
                        src => src.OrderItems.Sum(o => o.Price)));
        }
    }
}
