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
        }
    }
}
