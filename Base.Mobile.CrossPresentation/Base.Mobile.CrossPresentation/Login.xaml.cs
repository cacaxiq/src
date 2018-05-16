using Base.Mobile.CrossPresentation.Base;
using ReactiveUI;
using System.Reactive.Disposables;
using Xamarin.Forms.Xaml;

namespace Base.Mobile.CrossPresentation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPageBase<ViewModel.Login>
    {
		public Login ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, vm => vm.Username, c => c.UsernameEntry.Text)
                  .DisposeWith(disposables);

                this.Bind(ViewModel, vm => vm.Password, c => c.PasswordEntry.Text)
                  .DisposeWith(disposables);

                this.OneWayBind(ViewModel, x => x.LoginCommand, x => x.LoginButton.Command)
                  .DisposeWith(disposables);

                this.OneWayBind(ViewModel, x => x.IsLoading, x => x.LoginActivityIndicator.IsRunning)
                  .DisposeWith(disposables);
            });
        }
    }
}