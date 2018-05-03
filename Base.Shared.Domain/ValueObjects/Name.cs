using System.Collections.Generic;
using Flunt.Validations;

namespace Base.Shared.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        private Name() { }

        public Name(string firstName, string lastFirstName)
        {
            FirstName = firstName;
            LastName = lastFirstName;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(FirstName, "Name.FirstName", "Nome não pode ser nulo.")
                .IsNotNullOrEmpty(LastName, "Name.LastName", "Sobrenome não pode ser nulo.")
                .HasMaxLen(FirstName, 50, "Name.FirstName", "Nome excedeu o tamanho máximo.")
                .HasMaxLen(LastName, 50, "Name.LastName", "Sobrenome  excedeu o tamanho máximo."));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string FullName() { return $"{FirstName} {LastName}"; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
