namespace MyOnlineShop.Domain.Catalog.Exceptions.Products
{
    using MyOnlineShop.Domain.Common;

    public class InvalidProductException : BaseDomainException
    {
        public InvalidProductException()
        {

        }

        public InvalidProductException(string error)
        {
            this.Error = error;
        }
    }
}
