using Base.ViewModel.Model.Login;
using Base.ViewModel.ServiceApi.InteraceRefit;
using Base.ViewModel.ServiceApi.InterfaceApi;
using Base.ViewModel.ServiceApi.Service;
using Fusillade;
using System.Net.Http;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi
{
    public class LoginApi : ApiManager, ILoginApi
    {
        private string token;
        private IApiService<ILoginRefit> apiService;

        public LoginApi()
        {
            apiService = new ApiService<ILoginRefit>(Config.ApiUrl);
        }

        public Task<HttpResponseMessage> GetToken(UserInfoDTO userInfo)
        {
            return CallApi(apiService.GetApi(Priority.UserInitiated).GetToken(userInfo));
        }
    }
}
