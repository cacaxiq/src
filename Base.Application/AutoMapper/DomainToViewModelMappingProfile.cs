using AutoMapper;
using Base.Application.ViewModels;
using Base.Domain.Entities;

namespace Base.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Intention, IntentionViewModel>();

            CreateMap<Prospect, ProspectViewModel>()
                .ForMember(d => d.FirstName, o => o.MapFrom(p => p.Name.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(p => p.Name.LastName))
                .ForMember(d => d.Address, o => o.MapFrom(p => p.Email.Address))
                .ForMember(d => d.HomePhone, o => o.MapFrom(p => p.HomePhone.Number))
                .ForMember(d => d.CellPhone, o => o.MapFrom(p => p.CellPhone.Number))
                .ForMember(d => d.IsWhatsApp, o => o.MapFrom(p => p.CellPhone.IsWhatsApp))
                .ReverseMap();
        }
    }
}
