using Base.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Base.Application.Interfaces
{
    public interface IProspectAppService : IDisposable
    {
        IEnumerable<ProspectViewModel> GetAll();
        void Create(ProspectViewModel viewModel);
        void Update(ProspectViewModel model);
    }
}
