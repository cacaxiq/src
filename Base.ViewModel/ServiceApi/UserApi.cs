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
    public class UserApi : ApiManager, IUserApi
    {
        private string token;
        private IApiService<IUserRefit> apiService;

        public UserApi()
        {
            apiService = new ApiService<IUserRefit>(Config.ApiUrl);
        }

        public async Task<Response<UserInfoDTO>> Create(UserInfoDTO userInfo)
        {
            var user = new Response<UserInfoDTO>();
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(apiService.GetApi(Priority.UserInitiated).Create(userInfo, token));
            runningTasks.Add(task.Id, cts);

            await RunSafe(task, false);

            var response = task.Result; 

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                user = await Task.Run(() => JsonConvert.DeserializeObject<Response<UserInfoDTO>>(data));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => {
                    userDialogs.Alert("Unable to get data", "Error", "Ok");
                });
            }

            return user;
        }

        public async Task<Response<UserInfoDTO>> Update(UserInfoDTO userInfo)
        {
            var user = new Response<UserInfoDTO>();
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(apiService.GetApi(Priority.UserInitiated).Update(userInfo, token));
            runningTasks.Add(task.Id, cts);

            await RunSafe(task, false);

            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                user = await Task.Run(() => JsonConvert.DeserializeObject<Response<UserInfoDTO>>(data));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => {
                    userDialogs.Alert("Unable to get data", "Error", "Ok");
                });
            }

            return user;
        }
    }
}
