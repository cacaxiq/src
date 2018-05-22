using Base.ViewModel.Model.Prospect;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InterfaceApi
{
    public interface IProspectApi
    {
        Task<HttpResponseMessage> Create(ProspectDTO prospect);
        Task<HttpResponseMessage> Update(ProspectDTO prospect);
        Task<HttpResponseMessage> Delete(Guid id);
    }
}
