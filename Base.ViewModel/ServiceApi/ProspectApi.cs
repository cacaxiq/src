using Base.ViewModel.Model.Base;
using Base.ViewModel.Model.Login;
using Base.ViewModel.Model.Prospect;
using Base.ViewModel.ServiceApi.InteraceRefit;
using Base.ViewModel.ServiceApi.InterfaceApi;
using Base.ViewModel.ServiceApi.Service;
using Fusillade;
using Newtonsoft.Json;
using System;
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

        public async Task<Response<ProspectDTO>> Create(ProspectDTO _prospect)
        {
            var prospect = new Response<ProspectDTO>();
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(apiService.GetApi(Priority.UserInitiated).Create(_prospect, token));
            runningTasks.Add(task.Id, cts);

            await RunSafe(task, false);

            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                prospect = await Task.Run(() => JsonConvert.DeserializeObject<Response<ProspectDTO>>(data));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => {
                    userDialogs.Alert("Unable to get data", "Error", "Ok");
                });
            }

            return prospect;
        }

        public async Task<Response<ProspectDTO>> Update(ProspectDTO _prospect)
        {
            var prospect = new Response<ProspectDTO>();
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(apiService.GetApi(Priority.UserInitiated).Update(_prospect, token));
            runningTasks.Add(task.Id, cts);

            await RunSafe(task, false);

            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                prospect = await Task.Run(() => JsonConvert.DeserializeObject<Response<ProspectDTO>>(data));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => {
                    userDialogs.Alert("Unable to get data", "Error", "Ok");
                });
            }

            return prospect;
        }

        public async Task<Response<string>> Delete(Guid id)
        {
            var prospect = new Response<string>();
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(apiService.GetApi(Priority.UserInitiated).Delete(id, token));
            runningTasks.Add(task.Id, cts);

            await RunSafe(task, false);

            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                prospect = await Task.Run(() => JsonConvert.DeserializeObject<Response<string>>(data));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => {
                    userDialogs.Alert("Unable to get data", "Error", "Ok");
                });
            }

            return prospect;
        }
    }
}
