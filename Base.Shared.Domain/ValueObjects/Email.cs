using Flunt.Validations;
using System.Collections.Generic;

namespace Base.Shared.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        private Email() { }

        public Email(string address)
        {
            Address = address;
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email.Address", "E-mail inválido")
                .HasMaxLen(Address, 100, "Email.Address", "Email excedeu o tamanho máximo.")
              );
        }

        public string Address { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Address;
        }
    }
}
