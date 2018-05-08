using AutoMapper;
using Base.Application.ViewModels;
using Base.Domain.Entities;

namespace Base.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Intention, IntentionViewModel>()
                .ForMember(d => d.LowestPrice, o => o.MapFrom(p => p.LowestPrice))
                .ForMember(d => d.MaximumPrice, o => o.MapFrom(p => p.MaximumPrice))
                .ForMember(d => d.State, o => o.MapFrom(p => p.State))
                .ForMember(d => d.City, o => o.MapFrom(p => p.City))
                .ForMember(d => d.Neighborhood, o => o.MapFrom(p => p.Neighborhood))
                .ForMember(d => d.Rent, o => o.MapFrom(p => p.Rent))
                .ForMember(d => d.PropertySituation, o => o.MapFrom(p => p.PropertySituation))
                .ForMember(d => d.PropertyType, o => o.MapFrom(p => p.PropertyType))
                .ReverseMap();

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
