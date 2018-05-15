using Base.Shared.Domain.Entities;
using Base.Shared.Domain.ValueObjects;
using Flunt.Validations;

namespace Base.Domain.Entities
{
    public class User : Entity
    {
        public User(Name name, Email email, string accessKey, string login)
        {
            AccessKey = accessKey;
            Name = name;
            UserID = login;
            Email = email;

            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(AccessKey, "User.AccessKey", "Senha não pode ser nulo.")
               .HasMaxLen(AccessKey, 50, "User.AccessKey", "Senha  excedeu o tamanho máximo.")
               .HasMinLen(AccessKey, 6, "User.AccessKey", "Senha  não alcançou o tamanho mínimo.")
               .IsNotNullOrEmpty(UserID, "User.UserID", "Login não pode ser nulo.")
               .HasMaxLen(UserID, 20, "User.UserID", "Login  excedeu o tamanho máximo.")
               .HasMinLen(UserID, 5, "User.UserID", "Login  não alcançou o tamanho mínimo."),
               Name, Email);
        }

        protected User() { }

        public string AccessKey { get; private set; }
        public string UserID { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
    }
}
