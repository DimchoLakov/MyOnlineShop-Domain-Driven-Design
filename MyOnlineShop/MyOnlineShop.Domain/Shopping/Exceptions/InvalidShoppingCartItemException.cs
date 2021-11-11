namespace MyOnlineShop.Domain.Shopping.Exceptions
{
    using MyOnlineShop.Domain.Common;

    public class InvalidShoppingCartItemException : BaseDomainException
    {
        public InvalidShoppingCartItemException()
        {

        }

        public InvalidShoppingCartItemException(string error)
        {
            this.Error = error;
        }
    }
}
