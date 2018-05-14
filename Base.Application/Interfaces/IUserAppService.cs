using Base.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Base.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        UserViewModel GetById(Guid id);
        UserViewModel GetByUserID(string userID);
        IEnumerable<UserViewModel> GetAll();
        void Create(UserViewModel viewModel);
        void Update(UserViewModel viewModel);
        void Remove(Guid id);
    }
}
