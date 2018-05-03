using Base.Shared.Extension.String;
using Flunt.Validations;
using System.Collections.Generic;

namespace Base.Shared.Domain.ValueObjects
{
    public class CellPhone : ValueObject
    {
        private CellPhone() { }

        public CellPhone(string number, bool isWhatsApp = false)
        {
            IsWhatsApp = isWhatsApp;
            Number = number;

            AddNotifications(new Contract()
                .IsTrue(Number.Length == 11, "CellPhone.Number", "Telefone Celular não possui 11 digítos"));
        }

        public bool IsWhatsApp { get; private set; }
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
            yield return IsWhatsApp;
        }
    }
}
