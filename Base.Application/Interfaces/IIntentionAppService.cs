using Base.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Base.Application.Interfaces
{
    public interface IIntentionAppService : IDisposable
    {
        void Create(IntentionViewModel intentionViewModel);
        IEnumerable<IntentionViewModel> GetAll();
        IntentionViewModel GetById(Guid id);
    }
}
