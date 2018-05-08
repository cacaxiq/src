using System.Threading.Tasks;
using Base.Shared.Domain.Bus;
using Base.Shared.Domain.Command;
using Base.Shared.Domain.Event;
using MediatR;

namespace Base.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IEventStore _eventStore;
        private readonly IMediator _mediator;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            //if (!@event.MessageType.Equals("DomainNotification"))
            //    _eventStore?.Save(@event);

            return Publish(@event);
        }

        public void SendCommand<T>(T command) where T : Command
        {
            _mediator.Publish(command);
        }

        private Task Publish<T>(T message) where T : Message
        {
            return _mediator.Publish(message);
        }
    }
}
