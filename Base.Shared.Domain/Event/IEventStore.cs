namespace Base.Shared.Domain.Event
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
