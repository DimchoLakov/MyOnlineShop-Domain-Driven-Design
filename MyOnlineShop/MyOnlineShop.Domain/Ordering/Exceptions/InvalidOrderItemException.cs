namespace MyOnlineShop.Domain.Ordering.Exceptions
{
    using MyOnlineShop.Domain.Common;

    public class InvalidOrderItemException : BaseDomainException
    {
        public InvalidOrderItemException()
        {
        }

        public InvalidOrderItemException(string error)
        {
            this.Error = error;
        }
    }
}
