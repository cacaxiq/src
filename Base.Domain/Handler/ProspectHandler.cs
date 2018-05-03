using System.Threading;
using System.Threading.Tasks;
using Base.Domain.CommandHandlers;
using Base.Domain.Commands.Prospect;
using Base.Domain.Interface;
using Base.Shared.Domain.Bus;
using Base.Shared.Domain.Notification;
using MediatR;

namespace Base.Domain.Handler
{
    public class ProspectHandler : CommandHandler, INotificationHandler<CreateProspectCommand>
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

        public Task Handle(CreateProspectCommand command, CancellationToken cancellationToken)
        {
            command.FillEntities();

            if (command.Invalid)
            {
                NotifyValidationErrors(command);
                return Task.CompletedTask;
            }

            var prospect = prospectRepository.Add(command.Prospect);

            return Task.CompletedTask;
        }
    }
}
