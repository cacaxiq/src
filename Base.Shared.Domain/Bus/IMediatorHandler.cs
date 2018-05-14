using System.Threading.Tasks;

namespace Base.Shared.Domain.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command.Command;
        Task RaiseEvent<T>(T @event) where T : Event.Event;
    }
}
