using Base.ViewModel.Model.Base;
using Base.ViewModel.Model.Intention;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InterfaceApi
{
    public interface IIntentionApi
    {
        Task<Response<IntentionDTO>> Update(IntentionDTO userInfo);
        Task<Response<IntentionDTO>> Create(IntentionDTO userInfo);
        Task<Response<IEnumerable<IntentionDTO>>> GetByProspect(Guid prospectId);
        Task<Response<string>> Delete(Guid id);
    }
}
