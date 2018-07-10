using Base.ViewModel.Model.Intention;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InterfaceApi
{
    public interface IIntentionApi
    {
        Task<HttpResponseMessage> Update(IntentionDTO userInfo);
        Task<HttpResponseMessage> Create(IntentionDTO userInfo);
        Task<HttpResponseMessage> GetByProspect(Guid prospectId);
        Task<HttpResponseMessage> GetByUserEmail(string userEmail);
        Task<HttpResponseMessage> Delete(Guid id);
    }
}
