using System.Collections.Generic;

namespace Base.Shared.Domain.ValueObjects
{
    public abstract class Phone : ValueObject
    {
        private Phone() { }

        public Phone(string number)
        {
            Number = number;
        }

        protected string Number { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
        }
    }
}
