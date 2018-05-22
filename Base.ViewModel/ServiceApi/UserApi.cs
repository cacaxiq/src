using Base.ViewModel.Model.Login;
using Base.ViewModel.ServiceApi.InteraceRefit;
using Base.ViewModel.ServiceApi.InterfaceApi;
using Base.ViewModel.ServiceApi.Service;
using Fusillade;
using System.Net.Http;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi
{
    public class UserApi : ApiManager, IUserApi
    {
        private string token;
        private IApiService<IUserRefit> apiService;

        public UserApi()
        {
            apiService = new ApiService<IUserRefit>(Config.ApiUrl);
        }

        public Task<HttpResponseMessage> Create(UserInfoDTO userInfo)
        {
            return CallApi(apiService.GetApi(Priority.UserInitiated).Create(userInfo, token));
        }

        public Task<HttpResponseMessage> Update(UserInfoDTO userInfo)
        {
            return CallApi(apiService.GetApi(Priority.UserInitiated).Update(userInfo, token));
        }
    }
}
