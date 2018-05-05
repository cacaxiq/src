using Base.Shared.Domain.Event;
using System.Linq;

namespace Base.Shared.Domain.Command
{
    public abstract class Command : Message, ICommand
    {
        public virtual void FillEntities() { }

        public string Error()
        {
            return $"{Notifications.First().Property}:{Notifications.First().Message}";
        }
    }
}
