namespace MyOnlineShop.Application.Ordering.Queries.Details.Models
{
    using AutoMapper;
    using MyOnlineShop.Application.Common.InputOutputModels.Output.Address;
    using MyOnlineShop.Application.Ordering.Queries.Common;
    using MyOnlineShop.Domain.Ordering.Models.Orders;
    using System.Collections.Generic;

    public class OrderDetailsOutputModel : OrderOutputModel
    {
        public AddressOutputModel Address { get; set; } = default!;

        public IEnumerable<OrderItemDetailsOutputModel> OrderItems { get; set; } = new List<OrderItemDetailsOutputModel>();

        public override void Mapping(Profile profile)
        {
            profile
                .CreateMap<Order, OrderDetailsOutputModel>()
                .IncludeBase<Order, OrderOutputModel>();
        }
    }
}
