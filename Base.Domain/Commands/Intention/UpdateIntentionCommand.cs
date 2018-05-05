using Base.Domain.Commands.Intention;
using Base.Domain.Enums;
using Base.Shared.Enum;
using System;

namespace Base.Domain.Commands
{
    public class UpdateIntentionCommand : IntentionCommand
    {
        public UpdateIntentionCommand(
            Guid prospectId,
            decimal? rent,
            decimal lowestPrice,
            decimal maximumPrice,
            int bedroom,
            EState state,
            string city,
            string neighborhood,
            EPropertyType propertyType,
            EPropertySituation propertySituation)
        {
            ProspectId = prospectId;
            Rent = rent;
            LowestPrice = lowestPrice;
            MaximumPrice = maximumPrice;
            Bedroom = bedroom;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            PropertyType = propertyType;
            PropertySituation = propertySituation;
        }

        public Guid IntenttionId { get; protected set; }

        public override void FillEntities()
        {
            base.FillEntities();

            Intention.Prospect.UpdateEntity(ProspectId);
            Intention.UpdateEntity(IntenttionId);
        }
    }
}
