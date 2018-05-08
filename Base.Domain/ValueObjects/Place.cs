using Base.Shared.Domain.ValueObjects;
using Flunt.Validations;
using System.Collections.Generic;

namespace Base.Domain.ValueObjects
{
    public class Place : ValueObject
    {
        private Place() { }
        public Place(string state, string city, string neighborhood)
        {
            State = state;
            City = city;
            Neighborhood = neighborhood;

            AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(City, "Place.City", "Cidade deve ser preenchido.")
            .IsNotNullOrEmpty(Neighborhood, "Place.Neighborhood", "Bairro deve ser preenchido.")
            .HasMaxLen(City, 50, "Place.City", "Cidade excedeu o tamanho máximo.")
            .HasMaxLen(Neighborhood, 50, "Place.Neighborhood", "Bairro  excedeu o tamanho máximo."));
        }

        public string State { get; private set; }
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
