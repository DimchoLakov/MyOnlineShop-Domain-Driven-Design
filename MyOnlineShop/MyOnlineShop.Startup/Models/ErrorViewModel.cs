namespace MyOnlineShop.Startup.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } = default!;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public int? StatusCode { get; set; }
    }
}
