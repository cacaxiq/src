using System.Threading;
using System.Threading.Tasks;
using Base.Domain.CommandHandlers;
using Base.Domain.Commands.Prospect;
using Base.Domain.Interface;
using Base.Shared.Domain.Bus;
using Base.Shared.Domain.Notification;
using MediatR;

namespace Base.Domain.CommandHandlers
{
    public class ProspectHandler : CommandHandler,
        INotificationHandler<CreateProspectCommand>,
        INotificationHandler<UpdateProspectCommand>,
        INotificationHandler<RemoveProspectCommand>
    {
        IProspectRepository prospectRepository;

        public ProspectHandler(
            IProspectRepository _prospectRepository,
                IUnitOfWork uow,
                IMediatorHandler bus,
                INotificationHandler<DomainNotification> notifications)
                : base(uow, bus, notifications)
        {
            prospectRepository = _prospectRepository;
        }

        public Task Handle(CreateProspectCommand notification, CancellationToken cancellationToken)
        {
            notification.FillEntities();

            if (notification.Invalid)
            {
                NotifyValidationErrors(notification);
                return Task.CompletedTask;
            }

            if (prospectRepository.ExistProspectWithEmail(notification.Prospect.Email.Address))
            {
                _bus.RaiseEvent(new DomainNotification(notification.MessageType, "E-mail já foi cadastrado."));
                return Task.CompletedTask;
            }

            prospectRepository.Add(notification.Prospect);

            if (Commit())
            {
                return Task.CompletedTask;
            }
            else
            {
                _bus.RaiseEvent(new DomainNotification(notification.MessageType, "Não foi possivel salvar novo cliente."));
                return Task.CompletedTask;
            }
        }

        public Task Handle(UpdateProspectCommand notification, CancellationToken cancellationToken)
        {
            notification.FillEntities();

            if (notification.Invalid)
            {
                NotifyValidationErrors(notification);
                return Task.CompletedTask;
            }

            prospectRepository.Update(notification.Prospect);

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

        public Task Handle(RemoveProspectCommand notification, CancellationToken cancellationToken)
        {
            notification.FillEntities();

            if (notification.Invalid)
            {
                NotifyValidationErrors(notification);
                return Task.CompletedTask;
            }

            prospectRepository.Delete(notification.ProspectId);

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
