using Base.Shared.Domain.Event;
using Microsoft.EntityFrameworkCore;

namespace Base.ExternalData.Context
{
    public class EventStoreContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }
    }
}
