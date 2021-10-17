namespace MyOnlineShop.Domain.Catalog.Exceptions.Categories
{
    using MyOnlineShop.Domain.Common;

    public class InvalidCategoryException : BaseDomainException
    {
        public InvalidCategoryException()
        {

        }

        public InvalidCategoryException(string error)
        {
            this.Error = error;
        }
    }
}
