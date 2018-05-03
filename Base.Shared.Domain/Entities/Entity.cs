using Flunt.Notifications;
using System;

namespace Base.Shared.Domain.Entities
{
    public class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }

        public void UpdateEntity(Guid id)
        {
            Id = id;
        }
    }
}
