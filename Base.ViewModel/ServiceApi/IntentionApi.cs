using Base.ViewModel.Model.Base;
using Base.ViewModel.Model.Intention;
using Base.ViewModel.Model.Login;
using Base.ViewModel.ServiceApi.InteraceRefit;
using Base.ViewModel.ServiceApi.InterfaceApi;
using Base.ViewModel.ServiceApi.Service;
using Fusillade;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        public async Task<Response<IntentionDTO>> Create(IntentionDTO _intention)
        {
            var intention = new Response<IntentionDTO>();
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(apiService.GetApi(Priority.UserInitiated).Create(_intention, token));
            runningTasks.Add(task.Id, cts);

            await RunSafe(task, false);

            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                intention = await Task.Run(() => JsonConvert.DeserializeObject<Response<IntentionDTO>>(data));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    userDialogs.Alert("Unable to get data", "Error", "Ok");
                });
            }

            return intention;
        }

        public async Task<Response<string>> Delete(Guid id)
        {
            var intention = new Response<string>();
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(apiService.GetApi(Priority.UserInitiated).Delete(id, token));
            runningTasks.Add(task.Id, cts);

            await RunSafe(task, false);

            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                intention = await Task.Run(() => JsonConvert.DeserializeObject<Response<string>>(data));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    userDialogs.Alert("Unable to get data", "Error", "Ok");
                });
            }

            return intention;
        }

        public async Task<Response<IEnumerable<IntentionDTO>>> GetByProspect(Guid prospectId)
        {
            var intention = new Response<IEnumerable<IntentionDTO>>();
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(apiService.GetApi(Priority.UserInitiated).GetByProspect(prospectId, token));
            runningTasks.Add(task.Id, cts);

            await RunSafe(task, false);

            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                intention = await Task.Run(() => JsonConvert.DeserializeObject<Response<IEnumerable<IntentionDTO>>>(data));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    userDialogs.Alert("Unable to get data", "Error", "Ok");
                });
            }

            return intention;
        }

        public async Task<Response<IntentionDTO>> Update(IntentionDTO _intention)
        {
            var intention = new Response<IntentionDTO>();
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(apiService.GetApi(Priority.UserInitiated).Update(_intention, token));
            runningTasks.Add(task.Id, cts);

            await RunSafe(task, false);

            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                intention = await Task.Run(() => JsonConvert.DeserializeObject<Response<IntentionDTO>>(data));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    userDialogs.Alert("Unable to get data", "Error", "Ok");
                });
            }

            return intention;
        }
    }
}
