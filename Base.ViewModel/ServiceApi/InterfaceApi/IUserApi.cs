using Base.ViewModel.Model.Base;
using Base.ViewModel.Model.Login;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InterfaceApi
{
    public interface IUserApi
    {
        Task<Response<UserInfoDTO>> Update(UserInfoDTO userInfo);
        Task<Response<UserInfoDTO>> Create(UserInfoDTO userInfo);
    }
}
