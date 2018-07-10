using Base.Application.ViewModels;
using Base.Shared.Extension.String;
using Base.ViewModel.Base;
using Base.ViewModel.Helpers;
using Base.ViewModel.Model.Intention;
using Base.ViewModel.ServiceApi;
using Base.ViewModel.ServiceApi.InterfaceApi;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using Xamarin.Forms;

namespace Base.ViewModel
{
    public class IntentionsList : ViewModelBase
    {
        private IIntentionApi IntentionApi;

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set { this.RaiseAndSetIfChanged(ref _searchQuery, value); }
        }

        //List with search results once user start typing
        private ObservableCollection<IntentionDTO> _intentions;
        public ObservableCollection<IntentionDTO> Intentions
        {
            get => _intentions;
            private set
            {
                this.RaiseAndSetIfChanged(ref _intentions, value);
            }
        }

        //List with initial items retrieved from web service. This is mocked by CreateList() method.
        ObservableCollection<IntentionDTO> _intentionsSourceList;
        private ObservableCollection<IntentionDTO> IntentionsSourceList
        {
            get { return _intentionsSourceList; }
            set { this.RaiseAndSetIfChanged(ref _intentionsSourceList, value); }
        }

        public IntentionsList(IIntentionApi intentionApi = null)
        {
            IntentionApi = intentionApi ?? Locator.Current.GetService<IIntentionApi>();

            UrlPathSegment = "Lista Intenções de compra";
            HostScreen = Locator.Current.GetService<IScreen>();
            //CreateList();
            SetupReactiveObservables();
            SetIdAdMob();
        }

        protected void SetupReactiveObservables()
        {
            //When any value is provided in SearchViewEntry field and this value is not empty or null.
            //Throttle method here is responsible for delay displaying search result.
            //Once user finish typing, search query will be executed after two seconds.
            //Subscribe method here is responsible for filtering CarsSourceList and returning the result to Cars property.
            //Cars property is binded to CarsListViewControl in CarsListViewPage.

            this.WhenAnyValue(vm => vm.SearchQuery)
                .Throttle(TimeSpan.FromSeconds(2))
                .Where(x => !string.IsNullOrEmpty(x))
                .Subscribe(vm =>
                {
                    var filteredList = IntentionsSourceList.Where(brand => brand.City.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
                    Device.BeginInvokeOnMainThread(() => { Intentions = new ObservableCollection<IntentionDTO>(filteredList); });
                });

            //When empty value is provided in SearchViewEntry field (so user cleared it), display original list without filters.

            this.WhenAnyValue(vm => vm.SearchQuery).Where(x => string.IsNullOrEmpty(x)).Subscribe(vm =>
            {
                Intentions = IntentionsSourceList;
            });
        }

        #region Mock List Items

        private async void CreateList()
        {
            var result = new Ref<List<IntentionDTO>>();
            var user = SecurityData.GetUser();
            await RunSafe(ExecuteApi(IntentionApi.GetByUserEmail(user.User.Address), result));
            Intentions = IntentionsSourceList = new ObservableCollection<IntentionDTO>(result.Value);
        }
        #endregion
    }
}
