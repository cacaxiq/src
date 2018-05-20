using Base.ViewModel.ServiceApi;
using Base.ViewModel.ServiceApi.InterfaceApi;
using Splat;
using System;

namespace Base.CrossMobile.IoC
{
    public class AppBootstrapper : IEnableLogger
    {
        public AppBootstrapper()
        {
            RegisterDependencies();
        }

        public void RegisterDependencies()
        {
            Locator.CurrentMutable.RegisterConstant(new UserApi(), typeof(IUserApi));
            Locator.CurrentMutable.RegisterConstant(new IntentionApi(), typeof(IIntentionApi));
            Locator.CurrentMutable.RegisterConstant(new ProspectApi(), typeof(IProspectApi));
            Locator.CurrentMutable.RegisterConstant(new LoginApi(), typeof(ILoginApi));
        }
    }
}
