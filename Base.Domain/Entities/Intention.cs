using Base.Domain.Enums;
using Base.Domain.ValueObjects;
using Base.Shared.Domain.Entities;
using Base.Shared.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.Entities
{
    public class Intention : Entity
    {
        public Intention(
            Prospect prospect,
            decimal rent,
            PriceRange priceRange,
            int bedroom,
            Place place,
            EPropertyType propertyType,
            EPropertySituation propertySituation)
        {
            Prospect = prospect;
            Rent = rent;
            PriceRange = priceRange;
            Bedroom = bedroom;
            Place = place;
            PropertyType = propertyType;
            PropertySituation = propertySituation;

            AddNotifications(prospect, place, priceRange);
        }

        public Intention(
            Prospect prospect,
            PriceRange priceRange,
            int bedroom,
            Place place,
            EPropertyType propertyType,
            EPropertySituation propertySituation)
        {
            Prospect = prospect;
            PriceRange = priceRange;
            Bedroom = bedroom;
            Place = place;
            PropertyType = propertyType;
            PropertySituation = propertySituation;

            AddNotifications(prospect, place, priceRange);
        }

        public Intention(
            decimal rent,
            PriceRange priceRange,
            int bedroom,
            Place place,
            EPropertyType propertyType,
            EPropertySituation propertySituation)
        {
            Rent = rent;
            PriceRange = priceRange;
            Bedroom = bedroom;
            Place = place;
            PropertyType = propertyType;
            PropertySituation = propertySituation;

            AddNotifications(place, priceRange);
        }

        public Intention(
            PriceRange priceRange,
            int bedroom,
            Place place,
            EPropertyType propertyType,
            EPropertySituation propertySituation)
        {
            PriceRange = priceRange;
            Bedroom = bedroom;
            Place = place;
            PropertyType = propertyType;
            PropertySituation = propertySituation;

            AddNotifications(place, priceRange);
        }

        protected Intention() { }

        public Prospect Prospect { get; private set; }
        public decimal? Rent { get; private set; }
        public PriceRange PriceRange { get; private set; }
        public int Bedroom { get; private set; }
        public Place Place { get; private set; }
        public EPropertyType PropertyType { get; private set; }
        public EPropertySituation PropertySituation { get; private set; }

        public void AddProspect(Prospect prospect)
        {
            Prospect = prospect;
        }
    }
}
