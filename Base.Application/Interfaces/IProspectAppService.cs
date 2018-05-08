using Base.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Base.Application.Interfaces
{
    public interface IProspectAppService : IDisposable
    {
        ProspectViewModel GetById(Guid id);
        IEnumerable<ProspectViewModel> GetAll();
        void Create(ProspectViewModel viewModel);
        void Update(ProspectViewModel viewModel);
        void Remove(Guid id);
    }
}
