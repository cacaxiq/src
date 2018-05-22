using Base.ViewModel.Model.Intention;
using Base.ViewModel.ServiceApi.InteraceRefit;
using Base.ViewModel.ServiceApi.InterfaceApi;
using Base.ViewModel.ServiceApi.Service;
using Fusillade;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi
{
    public class IntentionApi : ApiManager, IIntentionApi
    {
        private string token;
        private IApiService<IIntentionRefit> apiService;

        public IntentionApi()
        {
            apiService = new ApiService<IIntentionRefit>(Config.ApiUrl);
        }

        public Task<HttpResponseMessage> Create(IntentionDTO intention)
        {
            return CallApi(apiService.GetApi(Priority.UserInitiated).Create(intention, token));
        }

        public Task<HttpResponseMessage> Delete(Guid id)
        {
            return CallApi(apiService.GetApi(Priority.UserInitiated).Delete(id, token));
        }

        public Task<HttpResponseMessage> GetByProspect(Guid prospectId)
        {
            return CallApi(apiService.GetApi(Priority.UserInitiated).GetByProspect(prospectId, token));
        }

        public Task<HttpResponseMessage> Update(IntentionDTO _intention)
        {
            return CallApi(apiService.GetApi(Priority.UserInitiated).Update(_intention, token));
        }
    }
}
