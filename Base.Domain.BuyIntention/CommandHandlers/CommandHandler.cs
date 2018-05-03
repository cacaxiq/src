using Base.Domain.Interface;
using Base.Shared.Domain.Bus;
using Base.Shared.Domain.Command;
using Base.Shared.Domain.Notification;
using MediatR;

namespace Base.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var notification in message.Notifications)
            {
                _bus.RaiseEvent(new DomainNotification(notification.Property, notification.Message));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "Nós temos um problema para persistir seus dados."));
            return false;
        }
    }
}
