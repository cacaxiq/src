using Base.ViewModel.Model.Base;
using Base.ViewModel.Model.Login;
using Base.ViewModel.Model.Prospect;
using Base.ViewModel.ServiceApi.InteraceRefit;
using Base.ViewModel.ServiceApi.InterfaceApi;
using Base.ViewModel.ServiceApi.Service;
using Fusillade;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Base.ViewModel.ServiceApi
{
    public class ProspectApi : ApiManager, IProspectApi
    {
        private string token;
        private IApiService<IPropesctRefit> apiService;

        public ProspectApi()
        {
            apiService = new ApiService<IPropesctRefit>(Config.ApiUrl);
        }

        public Task<HttpResponseMessage> Create(ProspectDTO _prospect)
        {
            return CallApi(apiService.GetApi(Priority.UserInitiated).Create(_prospect, token));
        }

        public Task<HttpResponseMessage> Update(ProspectDTO _prospect)
        {
            return CallApi(apiService.GetApi(Priority.UserInitiated).Update(_prospect, token)); ;
        }

        public Task<HttpResponseMessage> Delete(Guid id)
        {
            return CallApi(apiService.GetApi(Priority.UserInitiated).Delete(id, token)); ;
        }
    }
}
