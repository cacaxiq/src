using Base.Mobile.CrossPresentation.Base;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base.Mobile.CrossPresentation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntentionListView : ContentPageBase<ViewModel.Intention>
    {
        public IntentionListView()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Cars, x => x.CarsListView.ItemsSource).DisposeWith(disposables);
                this.Bind(ViewModel, x => x.SearchQuery, c => c.SearchViewEntry.Text).DisposeWith(disposables);
            });
        }
    }
}
