using Base.Mobile.CrossPresentation.Base;
using ReactiveUI;
using System.Reactive.Disposables;
using Xamarin.Forms.Xaml;

namespace Base.Mobile.CrossPresentation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntentionsList : ContentPageBase<ViewModel.IntentionsList>
    {
        public IntentionsList()
        {
            InitializeComponent();
                    }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Intentions, x => x.CarsListView.ItemsSource).DisposeWith(disposables);
                this.Bind(ViewModel, x => x.SearchQuery, c => c.SearchViewEntry.Text).DisposeWith(disposables);
            });
        }
    }
}
