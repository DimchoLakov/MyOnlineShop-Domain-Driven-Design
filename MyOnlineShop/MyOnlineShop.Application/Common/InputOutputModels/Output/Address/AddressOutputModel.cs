using MyOnlineShop.Application.Common.Mapping;

namespace MyOnlineShop.Application.Common.InputOutputModels.Output.Address
{
    public class AddressOutputModel : IMapFrom<Domain.Ordering.Models.Orders.Address>
    {
        public string AddressLine { get; set; } = default!;

        public string PostCode { get; set; } = default!;

        public string Town { get; set; } = default!;

        public string Country { get; set; } = default!;
    }
}
