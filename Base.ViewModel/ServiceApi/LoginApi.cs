using Base.ViewModel.Model.Base;
using Base.ViewModel.Model.Login;
using Base.ViewModel.ServiceApi.InteraceRefit;
using Base.ViewModel.ServiceApi.InterfaceApi;
using Base.ViewModel.ServiceApi.Service;
using Fusillade;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        public async Task<Response<AccessDTO>> GetToken(UserInfoDTO userInfo)
        {
            var access = new Response<AccessDTO>();
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(apiService.GetApi(Priority.UserInitiated).GetToken(userInfo));
            runningTasks.Add(task.Id, cts);

            await RunSafe(task, false);

            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                access = await Task.Run(() => JsonConvert.DeserializeObject<Response<AccessDTO>>(data));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    userDialogs.Alert(access.Errors[0], "Error", "Ok");
                });
            }

            return access;
        }
    }
}
