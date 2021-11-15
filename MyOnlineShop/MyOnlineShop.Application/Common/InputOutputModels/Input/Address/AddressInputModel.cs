namespace MyOnlineShop.Application.Common.InputOutputModels.Input.Address
{
    using System.ComponentModel.DataAnnotations;

    public class AddressInputModel
    {
        [Display(Name = "Address Line")]
        public string AddressLine { get; set; } = default!;

        [Display(Name = "Post Code")]
        public string PostCode { get; set; } = default!;

        public string Town { get; set; } = default!;

        public string Country { get; set; } = default!;
    }
}
