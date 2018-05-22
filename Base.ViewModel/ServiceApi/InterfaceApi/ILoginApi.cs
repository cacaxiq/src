using Base.ViewModel.Model.Login;
using System.Net.Http;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InterfaceApi
{
    public interface ILoginApi
    {
        Task<HttpResponseMessage> GetToken(UserInfoDTO userInfo);
    }
}
