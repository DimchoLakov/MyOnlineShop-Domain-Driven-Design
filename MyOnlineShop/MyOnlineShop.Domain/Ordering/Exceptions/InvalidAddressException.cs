namespace MyOnlineShop.Domain.Ordering.Exceptions
{
    using MyOnlineShop.Domain.Common;

    public class InvalidAddressException : BaseDomainException
    {
        public InvalidAddressException()
        {

        }
        public InvalidAddressException(string error)
        {
            this.Error = error;
        }
    }
}
