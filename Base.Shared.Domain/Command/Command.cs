using Flunt.Notifications;
using System.Linq;

namespace Base.Shared.Domain.Command
{
    public class Command : Notifiable, ICommand
    {
        public virtual void FillEntities() { }

        public string Error()
        {
            return $"{Notifications.First().Property}:{Notifications.First().Message}";
        }
    }
}
