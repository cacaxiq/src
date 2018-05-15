using Base.Domain.Commands.User;
using Base.Domain.Interface;
using Base.Shared.Domain.Bus;
using Base.Shared.Domain.Notification;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Domain.CommandHandlers
{
    public class UserHandler : CommandHandler,
        INotificationHandler<CreateUserCommand>,
        INotificationHandler<UpdateUserCommand>,
        INotificationHandler<RemoveUserCommand>
    {
        IUserRepository userRepository;

        public UserHandler(
                IUserRepository _userRepository,
                IUnitOfWork uow,
                IMediatorHandler bus,
                INotificationHandler<DomainNotification> notifications)
                : base(uow, bus, notifications)
        {
            userRepository = _userRepository;
        }

        public Task Handle(CreateUserCommand notification, CancellationToken cancellationToken)
        {
            notification.FillEntities();

            if (notification.Invalid)
            {
                NotifyValidationErrors(notification);
                return Task.CompletedTask;
            }

            if (userRepository.ExistUserWithEmailAndLogin(notification.User))
            {
                _bus.RaiseEvent(new DomainNotification(notification.MessageType, "Login ou e-mail já cadastrado."));
                return Task.CompletedTask;
            }

            userRepository.Add(notification.User);

            if (Commit())
            {
                return Task.CompletedTask;
            }
            else
            {
                _bus.RaiseEvent(new DomainNotification(notification.MessageType, "Não foi possível salvar novo usuário."));
                return Task.CompletedTask;
            }
        }

        public Task Handle(UpdateUserCommand notification, CancellationToken cancellationToken)
        {
            notification.FillEntities();

            if (notification.Invalid)
            {
                NotifyValidationErrors(notification);
                return Task.CompletedTask;
            }

            userRepository.Update(notification.User);

            if (Commit())
            {
                return Task.CompletedTask;
            }
            else
            {
                _bus.RaiseEvent(new DomainNotification(notification.MessageType, "Não foi possivel alterar cliente."));
                return Task.CompletedTask;
            }
        }

        public Task Handle(RemoveUserCommand notification, CancellationToken cancellationToken)
        {
            notification.FillEntities();

            if (notification.Invalid)
            {
                NotifyValidationErrors(notification);
                return Task.CompletedTask;
            }

            userRepository.Delete(notification.UserId);

            if (Commit())
            {
                return Task.CompletedTask;
            }
            else
            {
                _bus.RaiseEvent(new DomainNotification(notification.MessageType, "Não foi possivel alterar cliente."));
                return Task.CompletedTask;
            }
        }
    }
}
