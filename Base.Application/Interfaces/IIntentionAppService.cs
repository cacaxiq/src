﻿using Base.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Base.Application.Interfaces
{
    public interface IIntentionAppService : IDisposable
    {
        IEnumerable<IntentionViewModel> GetAll();
        IEnumerable<IntentionViewModel> GetAllByProspect(Guid prospectId);
        IEnumerable<IntentionViewModel> GetAllByUserEmail(string userEmail);
        IntentionViewModel GetById(Guid id);
        void Create(IntentionViewModel viewModel);
        void Update(IntentionViewModel viewModel);
        void Remove(Guid id);
    }
}
