namespace MyOnlineShop.Domain.Ordering.Exceptions
{
    using MyOnlineShop.Domain.Common;

    public class InvalidOrderException : BaseDomainException
    {
        public InvalidOrderException()
        {
        }

        public InvalidOrderException(string error)
        {
            this.Error = error;
        }
    }
}
