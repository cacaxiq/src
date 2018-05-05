using AutoMapper;
using Base.Application.ViewModels;
using Base.Domain.Commands;
using Base.Domain.Commands.Prospect;

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

            CreateMap<ProspectViewModel, CreateProspectCommand>()
                    .ConstructProjectionUsing(c => new CreateProspectCommand(
                        c.Address,
                        c.FirstName,
                        c.LastName,
                        c.CellPhone,
                        c.IsWhatsApp,
                        c.HomePhone)).ForAllOtherMembers(c => c.Ignore());

            CreateMap<ProspectViewModel, UpdateProspectCommand>()
                    .ConstructProjectionUsing(c => new UpdateProspectCommand(
                        c.Id,
                        c.Address,
                        c.FirstName,
                        c.LastName,
                        c.CellPhone,
                        c.IsWhatsApp,
                        c.HomePhone)).ForAllOtherMembers(c => c.Ignore());
        }
    }
}
