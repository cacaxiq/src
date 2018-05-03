using Base.Shared.Domain.Event;
using System;
using System.Collections.Generic;

namespace Base.ExternalData.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}