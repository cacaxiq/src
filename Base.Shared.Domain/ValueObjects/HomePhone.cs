using Base.Shared.Extension.String;
using Flunt.Validations;
using System.Collections.Generic;

namespace Base.Shared.Domain.ValueObjects
{
    public class HomePhone : ValueObject
    {
        private HomePhone() { }

        public HomePhone(string number)
        {
            Number = number;

            AddNotifications(new Contract()
                .IsTrue(Number.Length == 10, "HomePhone.Number", "Telefone Residencial não possui 10 digítos"));
        }

        public string Number { get; private set; }

        public string Formatted()
        {
            if (Valid)
                return Number.FormatCellPhone();

            return string.Empty;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
        }
    }
}
