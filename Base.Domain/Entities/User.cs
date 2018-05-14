using Base.Shared.Domain.Entities;
using Base.Shared.Domain.ValueObjects;
using Flunt.Validations;

namespace Base.Domain.Entities
{
    public class User : Entity
    {
        public User(string accessKey, Name name, string login)
        {
            AccessKey = accessKey;
            Name = name;
            Login = login;

            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(AccessKey, "User.AccessKey", "Senha não pode ser nulo.")
               .HasMaxLen(AccessKey, 50, "User.AccessKey", "Senha  excedeu o tamanho máximo.")
               .HasMinLen(AccessKey, 6, "User.AccessKey", "Senha  não alcançou o tamanho mínimo.")
               .IsNotNullOrEmpty(Login, "User.Login", "Login não pode ser nulo.")
               .HasMaxLen(Login, 20, "User.Login", "Login  excedeu o tamanho máximo.")
               .HasMinLen(Login, 5, "User.Login", "Login  não alcançou o tamanho mínimo."));
        }

        protected User() { }

        public string AccessKey { get; private set; }
        public string Login { get; private set; }
        public Name Name { get; private set; }
    }
}
