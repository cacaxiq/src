using Acr.UserDialogs;
using Base.Constants;
using Newtonsoft.Json;
using ReactiveUI;
using Splat;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Base.ViewModel.Base
{
    public abstract class ViewModelBase : ReactiveObject, IRoutableViewModel
    {
        protected IUserDialogs Dialog = UserDialogs.Instance;
        public bool IsBusy { get; set; }
        public string AdUnitId { get; set; }

        public string UrlPathSegment
        {
            get;
            protected set;
        }

        public IScreen HostScreen
        {
            get;
            protected set;
        }

        public ViewModelActivator Activator
        {
            get { return viewModelActivator; }
        }

        protected readonly ViewModelActivator viewModelActivator = new ViewModelActivator();

        public ViewModelBase(IScreen hostScreen = null)
        {
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }

        protected void SetIdAdMob()
        {
            if (Device.RuntimePlatform == Device.iOS)
                AdUnitId = AppConstants.AdmobKeyiOS;
            else
                AdUnitId = AppConstants.AdmobKeyAndroid;
        }

        public async Task RunSafe(Task task, bool ShowLoading = true, string loadinMessage = null)
        {
            try
            {
                if (IsBusy) return;

                IsBusy = true;

                if (ShowLoading) UserDialogs.Instance.ShowLoading(loadinMessage ?? "Loading...");

                await task;
            }
            catch (Exception e)
            {
                IsBusy = false;
                UserDialogs.Instance.HideLoading();
                Debug.WriteLine(e.ToString());
                await Dialog.AlertAsync("Check your internet connection", "Error", "Ok");
            }
            finally
            {
                IsBusy = false;
                if (ShowLoading) UserDialogs.Instance.HideLoading();
            }
        }

        public async Task RunSafe(Task<bool> task, bool ShowLoading = true, string loadinMessage = null)
        {
            try
            {
                if (IsBusy) return;

                IsBusy = true;

                if (ShowLoading) UserDialogs.Instance.ShowLoading(loadinMessage ?? "Loading...");

                await task;
            }
            catch (Exception e)
            {
                IsBusy = false;
                UserDialogs.Instance.HideLoading();
                Debug.WriteLine(e.ToString());
                await Dialog.AlertAsync("Check your internet connection", "Error", "Ok");
            }
            finally
            {
                IsBusy = false;
                if (ShowLoading) UserDialogs.Instance.HideLoading();
            }
        }

        public async Task ExecuteApi<TOutService>(Task<HttpResponseMessage> task, Ref<TOutService> property)
        {
            var result = await task;

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                property.Value = await Task.Run(() => JsonConvert.DeserializeObject<TOutService>(response));
            }
            else
            {
                await Dialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
        }

        public async Task<bool> ExecuteApiIsValid<TOutService>(Task<HttpResponseMessage> task, TOutService property)
        {
            var result = await task;

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                property = await Task.Run(() => JsonConvert.DeserializeObject<TOutService>(response));
                return true;
            }
            else
            {
                await Dialog.AlertAsync("Unable to get data", "Error", "Ok");
                return false;
            }
        }
    }
}
