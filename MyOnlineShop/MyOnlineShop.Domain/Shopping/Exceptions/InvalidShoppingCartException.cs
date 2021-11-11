namespace MyOnlineShop.Domain.Shopping.Exceptions
{
    using MyOnlineShop.Domain.Common;

    public class InvalidShoppingCartException : BaseDomainException
    {
        public InvalidShoppingCartException()
        {

        }

        public InvalidShoppingCartException(string error)
        {
            this.Error = error;
        }
    }
}
