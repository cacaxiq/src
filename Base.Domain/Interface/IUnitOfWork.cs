using Base.Shared.Domain.Command;
using System;

namespace Base.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
