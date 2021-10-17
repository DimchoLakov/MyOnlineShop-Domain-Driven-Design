namespace MyOnlineShop.Domain.Catalog.Exceptions.Products
{
    using MyOnlineShop.Domain.Common;

    public class InvalidProductOptionException : BaseDomainException
    {
        public InvalidProductOptionException()
        {

        }

        public InvalidProductOptionException(string error)
        {
            this.Error = error;
        }
    }
}
