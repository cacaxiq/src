using Base.ViewModel.Model.Login;
using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InteraceRefit
{
    public interface ILoginRefit
    {
        [Post("/api/Token")]
        Task<HttpResponseMessage> GetToken([Body]UserInfoDTO userInfo);
    }
}
