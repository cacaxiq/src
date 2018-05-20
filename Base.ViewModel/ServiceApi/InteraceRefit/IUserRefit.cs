using Base.ViewModel.Model.Login;
using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InteraceRefit
{
    public interface IUserRefit
    {
        [Put("/api/Users")]
        Task<HttpResponseMessage> Update([Body]UserInfoDTO userInfo, [Header("Authorization")] string token);

        [Post("/api/Users")]
        Task<HttpResponseMessage> Create([Body]UserInfoDTO userInfo, [Header("Authorization")] string token);
    }
}
