using Base.ViewModel.Model;
using Base.ViewModel.Model.Base;
using Base.ViewModel.Model.Prospect;
using System;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InterfaceApi
{
    public interface IProspectApi
    {
        Task<Response<ProspectDTO>> Create(ProspectDTO prospect);
        Task<Response<ProspectDTO>> Update(ProspectDTO prospect);
        Task<Response<string>> Delete(Guid id);
    }
}
