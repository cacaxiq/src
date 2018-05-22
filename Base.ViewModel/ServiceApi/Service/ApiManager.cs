using Acr.UserDialogs;
using Polly;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Base.ViewModel.ServiceApi.Service
{
    public abstract class ApiManager
    {
        public IUserDialogs userDialogs = UserDialogs.Instance;
        public bool IsConnected { get; set; }
        public Dictionary<int, CancellationTokenSource> runningTasks = new Dictionary<int, CancellationTokenSource>();

        public ApiManager()
        {
            IsConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        void OnConnectivityChanged(ConnectivityChangedEventArgs e)
        {
            IsConnected = e.NetworkAccess == NetworkAccess.Internet;

            if (!(e.NetworkAccess == NetworkAccess.Internet))
            {
                // Cancel All Running Task
                var items = runningTasks.ToList();
                foreach (var item in items)
                {
                    item.Value.Cancel();
                    runningTasks.Remove(item.Key);
                }
            }
        }

        protected Task<HttpResponseMessage> CallApi(Task<HttpResponseMessage> _task)
        {
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(_task);
            runningTasks.Add(task.Id, cts);
            return task;
        }

        private async Task<TData> RemoteRequestAsync<TData>(Task<TData> task)
            where TData : HttpResponseMessage,
            new()
        {
            TData data = new TData();

            if (!IsConnected)
            {
                var strngResponse = "There's not a network connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(strngResponse);

                userDialogs.Toast(strngResponse, TimeSpan.FromSeconds(1));
                return data;
            }

            data = await Policy.Handle<WebException>().Or<ApiException>().Or<TaskCanceledException>().WaitAndRetryAsync
            (
                retryCount: 2,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt))
            )
            .ExecuteAsync(async () =>
            {
                var result = await task;
                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //Logout the user 
                }
                runningTasks.Remove(task.Id);
                return result;
            });

            return data;
        }
    }
}
