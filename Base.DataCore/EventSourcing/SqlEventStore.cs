using Base.ExternalData.Repository.EventSourcing;
using Base.Shared.Domain.Event;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.ExternalData.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        // private readonly IUser _user;

        //public SqlEventStore(IEventStoreRepository eventStoreRepository, IUser user)
        //{
        //    _eventStoreRepository = eventStoreRepository;
        //    _user = user;
        //}
        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "User");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
