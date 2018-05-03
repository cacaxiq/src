using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Domain.Bus
{
    public interface IMediatorHandler
    {
        void SendCommand<T>(T command) where T : Command.Command;
        Task RaiseEvent<T>(T @event) where T : Event.Event;
    }
}
