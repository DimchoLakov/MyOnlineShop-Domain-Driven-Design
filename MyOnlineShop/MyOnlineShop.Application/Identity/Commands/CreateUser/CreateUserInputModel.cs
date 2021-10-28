namespace MyOnlineShop.Application.Identity.Commands.CreateUser
{
    public class CreateUserInputModel : UserInputModel
    {
        public CreateUserInputModel(
            string email,
            string password,
            string firstName,
            string lastName)
        {
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; } = default!;

        public string LastName { get; private set; } = default!;
    }
}
