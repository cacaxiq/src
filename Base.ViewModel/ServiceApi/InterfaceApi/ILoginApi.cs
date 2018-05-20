﻿using Base.ViewModel.Model.Base;
using Base.ViewModel.Model.Login;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InterfaceApi
{
    public interface ILoginApi
    {
        Task<Response<AccessDTO>> GetToken(UserInfoDTO userInfo);
    }
}
