using Base.Domain.Enums;
using Base.Domain.ValueObjects;
using Base.Shared.Domain.Command;
using Base.Shared.Domain.ValueObjects;
using Base.Shared.Enum;
using System;

namespace Base.Domain.Commands.Intention
{
    public abstract class IntentionCommand : Command
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

        public override void FillEntities()
        {
            Intention = new Entities.Intention(LowestPrice, MaximumPrice, Bedroom, State, City, Neighborhood, PropertyType, PropertySituation);

            if (Rent.HasValue)
                Intention.AddRent(Rent.Value);
        }
    }
}
