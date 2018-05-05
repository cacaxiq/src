using Flunt.Notifications;
using MediatR;
using System;

namespace Base.Shared.Domain.Event
{
    public abstract class Message : Notifiable, INotification
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
