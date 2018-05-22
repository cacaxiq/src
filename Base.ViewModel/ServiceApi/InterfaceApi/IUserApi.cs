using Base.ViewModel.Model.Login;
using System.Net.Http;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InterfaceApi
{
    public interface IUserApi
    {
        Task<HttpResponseMessage> Update(UserInfoDTO userInfo);
        Task<HttpResponseMessage> Create(UserInfoDTO userInfo);
    }
}
