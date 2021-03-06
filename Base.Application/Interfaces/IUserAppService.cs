﻿using Base.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        UserViewModel GetById(Guid id);
        UserViewModel GetByUserID(string userID);
        IEnumerable<UserViewModel> GetAll();
        void Update(UserViewModel viewModel);
        void Remove(Guid id);
        Task<UserViewModel> Create(UserViewModel viewModel);
    }
}
