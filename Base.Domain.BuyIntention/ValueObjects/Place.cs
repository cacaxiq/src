using System.Collections.Generic;
using Base.Shared.Domain.ValueObjects;
using Base.Shared.Enum;
using Flunt.Validations;

namespace Base.Domain.ValueObjects
{
    public class Place :  ValueObject
    {
        public Place(EState state, string city, string neighborhood)
        {
            State = state;
            City = city;
            Neighborhood = neighborhood;

            AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(City, "Place.City", "Cidade deve ser preenchido.")
            .IsNotNullOrEmpty(Neighborhood, "Place.Neighborhood", "Bairro deve ser preenchido."));
        }

        public EState State { get; private set; }
        public string City { get; private set; }
        public string Neighborhood { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return State;
            yield return City;
            yield return Neighborhood;

        }
    }
}
