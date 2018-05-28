using Base.ViewModel.Base;
using Base.ViewModel.Model.Login;
using Base.ViewModel.ServiceApi.InterfaceApi;
using ReactiveUI;
using Splat;
using System;
using System.Reactive.Linq;

namespace Base.ViewModel
{
    public class Login : ViewModelBase
    {
        string _userName;
        public string Username
        {
            get { return _userName; }
            set { this.RaiseAndSetIfChanged(ref _userName, value); }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }

        public ReactiveCommand LoginCommand { get; set; }
        private ILoginApi LoginApi;

        ObservableAsPropertyHelper<bool> _isLoading;
        public bool IsLoading
        {
            get { return _isLoading?.Value ?? false; }
        }

        ObservableAsPropertyHelper<bool> _isValid;
        public bool IsValid
        {
            get { return _isValid?.Value ?? false; }
        }

        public Login(ILoginApi loginApi = null)
        {
            LoginApi = loginApi ?? Locator.Current.GetService<ILoginApi>();

            UrlPathSegment = "ReactiveUI with Xamarin!";
            HostScreen = Locator.Current.GetService<IScreen>();
            PrepareObservables();
        }

        private void PrepareObservables()
        {

            this.WhenAnyValue(e => e.Username, p => p.Password, (emailAddress, password) => (!string.IsNullOrEmpty(emailAddress)) && !string.IsNullOrEmpty(password) && password.Length > 5)
                .ToProperty(this, v => v.IsValid, out _isValid);

            var canExecuteLogin = this.WhenAnyValue(x => x.IsLoading, x => x.IsValid, (isLoading, IsValid) => !isLoading && IsValid);

            LoginCommand = ReactiveCommand.CreateFromTask(
              async execute =>
              {
                  var accessDTO = new Ref<AccessDTO>();
                  await RunSafe(ExecuteApi(LoginApi.GetToken(new UserInfoDTO { AccessKey = Password, UserId = Username }), accessDTO));
                  if (accessDTO.Value.Authenticated)
                      HostScreen.Router.Navigate.Execute(new IntentionsList()).Subscribe();
              }, canExecuteLogin);


            this.WhenAnyObservable(x => x.LoginCommand.IsExecuting)
              .StartWith(false)
              .ToProperty(this, x => x.IsLoading, out _isLoading);
        }
    }
}
