namespace MyOnlineShop.Startup.Models
{
    using System;

    public class ErrorViewModel
    {
        public string RequestId { get; set; } = default!;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
