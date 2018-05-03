using Base.Domain.CommandHandlers;
using Base.Domain.Commands;
using Base.Domain.Interface;
using Base.Shared.Domain.Bus;
using Base.Shared.Domain.Command;
using Base.Shared.Domain.Notification;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Domain.Handler
{
    public class IntentionHandler : CommandHandler, INotificationHandler<CreateIntentionCommand>
    {
        IIntentionRepository intentionRepository;
        IProspectRepository prospectRepository;

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
        }

        public Task Handle(CreateIntentionCommand command, CancellationToken cancellationToken)
        {
            command.FillEntities();

            if (command.Invalid)
            {
                NotifyValidationErrors(command);
                return Task.CompletedTask;
            }

            var prospect = prospectRepository.Get(command.ProspectId);

            command.Intention.AddProspect(prospect);

            var result = intentionRepository.Add(command.Intention);

            return Task.CompletedTask;
        }

        //public ICommandResult Handle(CreateIntentionCommand command)
        //{
        //    command.FillEntities();
        //    if (command.Invalid)
        //        return new CommanResult(false, command.Error());

        //    var prospect = prospectRepository.GetById(command.ProspectId);

        //    command.Intention.AddProspect(prospect);

        //    intentionRepository.Add(command.Intention);

        //    return new CommanResult(true, "Intenção adicionada com sucesso");
        //}
    }
}
