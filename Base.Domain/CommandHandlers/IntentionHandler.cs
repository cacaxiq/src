using Base.Domain.CommandHandlers;
using Base.Domain.Commands;
using Base.Domain.Interface;
using Base.Shared.Domain.Bus;
using Base.Shared.Domain.Command;
using Base.Shared.Domain.Notification;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Domain.CommandHandlers
{
    public class IntentionHandler : CommandHandler,
        INotificationHandler<CreateIntentionCommand>,
        INotificationHandler<UpdateIntentionCommand>,
        INotificationHandler<RemoveIntentionCommand>
    {
        private readonly IIntentionRepository intentionRepository;
        private readonly IProspectRepository prospectRepository;
        private readonly IMediatorHandler Bus;

        public IntentionHandler(
            IIntentionRepository _intentionRepository,
            IProspectRepository _prospectRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            intentionRepository = _intentionRepository;
            prospectRepository = _prospectRepository;
            Bus = bus;
        }

        public Task Handle(CreateIntentionCommand notification, CancellationToken cancellationToken)
        {
            notification.FillEntities();

            if (notification.Invalid)
            {
                NotifyValidationErrors(notification);
                return Task.CompletedTask;
            }

            notification.Intention.AddProspect(notification.ProspectId);

            intentionRepository.Add(notification.Intention);

            if (Commit())
            {
                return Task.CompletedTask;
            }
            else
            {
                Bus.RaiseEvent(new DomainNotification(notification.MessageType, "Não foi possivel salvar intenção de compra."));
                return Task.CompletedTask;
            }
        }

        public Task Handle(UpdateIntentionCommand notification, CancellationToken cancellationToken)
        {
            notification.FillEntities();

            if (notification.Invalid)
            {
                NotifyValidationErrors(notification);
                return Task.CompletedTask;
            }


            intentionRepository.Update(notification.Intention);

            if (Commit())
            {
                return Task.CompletedTask;
            }
            else
            {
                Bus.RaiseEvent(new DomainNotification(notification.MessageType, "Não foi possivel alterar intenção de compra."));
                return Task.CompletedTask;
            }
        }

        public Task Handle(RemoveIntentionCommand notification, CancellationToken cancellationToken)
        {
            notification.FillEntities();

            if (notification.Invalid)
            {
                NotifyValidationErrors(notification);
                return Task.CompletedTask;
            }

            intentionRepository.Delete(notification.IntenttionId);

            if (Commit())
            {
                return Task.CompletedTask;
            }
            else
            {
                Bus.RaiseEvent(new DomainNotification(notification.MessageType, "Não foi possivel remover intenção de compra."));
                return Task.CompletedTask;
            }
        }
    }
}
