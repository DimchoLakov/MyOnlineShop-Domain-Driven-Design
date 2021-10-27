namespace MyOnlineShop.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using MyOnlineShop.Application.Identity;
    using MyOnlineShop.Domain.Common.Models;
    using MyOnlineShop.Infrastructure.Identity.Exceptions;
    using System;
    using static MyOnlineShop.Domain.Identity.ModelConstants.User;

    public class User : IdentityUser, IUser
    {
        internal User(
            string firstName,
            string lastName,
            string email)
        {
            this.Validate(
                firstName,
                lastName,
                email);

            this.FirstName = firstName;
            this.LastName = lastName;
            base.Email = email;
        }

        public string FirstName { get; private set; } = default!;

        public string LastName { get; private set; } = default!;

        private void Validate(
            string firstName,
            string lastName,
            string email)
        {
            this.ValidateFirstName(firstName);
            this.ValidateLastName(lastName);
            this.ValidateEmail(email);
        }

        private void ValidateFirstName(string firstName)
        {
            Guard.ForStringLength<InvalidUserException>(firstName, FirstNameMinLength, FirstNameMaxLength, nameof(this.FirstName));
        }

        private void ValidateLastName(string lastName)
        {
            Guard.ForStringLength<InvalidUserException>(lastName, LastNameMinLength, LastNameMaxLength, nameof(this.LastName));
        }

        private void ValidateEmail(string email)
        {
            Guard.AgainstEmptyString<InvalidUserException>(email, nameof(this.Email));
        }
    }
}
