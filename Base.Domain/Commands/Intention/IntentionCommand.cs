using AutoMapper;
using Base.Domain.Enums;
using Base.Domain.ValueObjects;
using Base.Shared.Domain.Command;
using Base.Shared.Enum;
using MediatR;
using System;

namespace Base.Domain.Commands.Intention
{
    public class IntentionCommand : Command, IRequest<ICommandResult>
    {
        public Guid ProspectId { get; protected set; }
        public decimal? Rent { get; protected set; }
        public decimal LowestPrice { get; protected set; }
        public decimal MaximumPrice { get; protected set; }
        public int Bedroom { get; protected set; }
        public EState State { get; protected set; }
        public string City { get; protected set; }
        public string Neighborhood { get; protected set; }
        public EPropertyType PropertyType { get; protected set; }
        public EPropertySituation PropertySituation { get; protected set; }

        public Entities.Intention Intention { get; protected set; }
        public PriceRange PriceRange { get; protected set; }
        public Place Place { get; protected set; }

        public override void FillEntities()
        {
            Place = new Place(State, City, Neighborhood);
            PriceRange = new PriceRange(LowestPrice, MaximumPrice);
            if (Rent.HasValue)
                Intention = new Entities.Intention(Rent.Value, PriceRange, Bedroom, Place, PropertyType, PropertySituation);
            else
                Intention = new Entities.Intention(PriceRange, Bedroom, Place, PropertyType, PropertySituation);

            AddNotifications(Place, PriceRange, Intention);
        }
    }
}
