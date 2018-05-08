using Base.Domain.Enums;
using Base.Domain.ValueObjects;
using Base.Shared.Domain.Entities;
using Base.Shared.Domain.ValueObjects;
using Base.Shared.Enum;
using Flunt.Validations;
using System;

namespace Base.Domain.Entities
{
    public class Intention : Entity
    {
        public Intention(
            decimal lowestPrice, 
            decimal maximumPrice,
            int bedroom, 
            EState state, 
            string city, 
            string neighborhood,
            EPropertyType propertyType,
            EPropertySituation propertySituation)
        {
            LowestPrice = lowestPrice;
            MaximumPrice = maximumPrice;
            Bedroom = bedroom;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            PropertyType = propertyType;
            PropertySituation = propertySituation;

            AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(City, "Intention.City", "Cidade deve ser preenchido.")
            .HasMaxLen(City, 50, "Intention.City", "Cidade excedeu o tamanho máximo.")
            .IsNotNullOrEmpty(Neighborhood, "Intention.Neighborhood", "Bairro deve ser preenchido.")
            .HasMaxLen(Neighborhood, 50, "Intention.Neighborhood", "Bairro  excedeu o tamanho máximo.")
            .IsGreaterThan(MaximumPrice, LowestPrice, "Intention.LowestPrice", "Preço minímo não pode ser maior que preço máximo."));
        }

        protected Intention() { }

        public Guid ProspectId { get; private set; }
        public decimal? Rent { get; private set; }
        public decimal LowestPrice { get; private set; }
        public decimal MaximumPrice { get; private set; }
        public int Bedroom { get; private set; }
        public EState State { get; private set; }
        public string City { get; private set; }
        public string Neighborhood { get; private set; }
        public EPropertyType PropertyType { get; private set; }
        public EPropertySituation PropertySituation { get; private set; }

        public void AddProspect(Guid prospect)
        {
            ProspectId = prospect;
        }

        public void AddRent(decimal rent)
        {
            Rent = rent;
        }
    }
}
