using System.Collections.Generic;
using Base.Shared.Domain.ValueObjects;
using Flunt.Validations;

namespace Base.Domain.ValueObjects
{
    public class PriceRange : ValueObject
    {
        private PriceRange() { }

        public PriceRange(decimal lowestPrice, decimal maximumPrice)
        {
            LowestPrice = lowestPrice;
            MaximumPrice = maximumPrice;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(MaximumPrice, LowestPrice, "PriceRange.LowestPrice", "Preço minímo não pode ser maior que preço máximo."));
        }

        public decimal LowestPrice { get; private set; }
        public decimal MaximumPrice { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return LowestPrice;
            yield return MaximumPrice;
        }
    }
}
