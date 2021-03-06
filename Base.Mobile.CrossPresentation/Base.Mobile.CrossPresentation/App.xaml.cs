﻿using Base.ViewModel.ServiceApi;
using Base.ViewModel.ServiceApi.InterfaceApi;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;

namespace Base.Mobile.CrossPresentation
{
    public partial class App : Xamarin.Forms.Application, IScreen
    {
        public RoutingState Router { get; set; }

        public App()
        {
            InitializeComponent();

            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Locator.CurrentMutable.Register(() => new Login(), typeof(IViewFor<ViewModel.Login>));
            Locator.CurrentMutable.Register(() => new IntentionsList(), typeof(IViewFor<ViewModel.IntentionsList>));
            Locator.CurrentMutable.RegisterConstant(new UserApi(), typeof(IUserApi));
            Locator.CurrentMutable.RegisterConstant(new IntentionApi(), typeof(IIntentionApi));
            Locator.CurrentMutable.RegisterConstant(new ProspectApi(), typeof(IProspectApi));
            Locator.CurrentMutable.RegisterConstant(new LoginApi(), typeof(ILoginApi));

            Router.NavigateAndReset.Execute(new ViewModel.Login());

            MainPage = new RoutedViewHost();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
