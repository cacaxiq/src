using Base.ViewModel.Model.Login;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Base.ViewModel.Helpers
{
    public static class SecurityData
    {
        public static Task SaveToken(string token)
        {
            SecureStorage.SetAsync("token", token);
            return Task.CompletedTask;
        }

        public static Task<string> GetToken(string token)
        {
            return SecureStorage.GetAsync("token");
        }

        public static Task SaveUser(AccessDTO user)
        {
            SaveToken(user.AccessToken).ConfigureAwait(false);
            SecureStorage.SetAsync("user", JsonConvert.SerializeObject(user));
            return Task.CompletedTask;
        }

        public static AccessDTO GetUser()
        {
            SecureStorage.GetAsync("user").ContinueWith((result) => { return JsonConvert.DeserializeObject<AccessDTO>(result.Result); });
            return new AccessDTO();
        }
    }
}
