using AutoMapper;
using Base.Application.ViewModels;
using Base.Domain.Commands;

namespace Base.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<IntentionViewModel, CreateIntentionCommand>()
                    .ConstructProjectionUsing(c => new CreateIntentionCommand(
                        c.ProspectId,
                        c.Rent,
                        c.LowestPrice,
                        c.MaximumPrice,
                        c.Bedroom,
                        c.State,
                        c.City,
                        c.Neighborhood,
                        c.PropertyType,
                        c.PropertySituation)).ForAllOtherMembers(c => c.Ignore());
        }
    }
}
