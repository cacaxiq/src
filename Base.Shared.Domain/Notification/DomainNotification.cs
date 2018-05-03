using Base.Shared.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Shared.Domain.Notification
{
    public class DomainNotification : Event.Event
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
