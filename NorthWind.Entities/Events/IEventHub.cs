namespace NorthWind.Entities.Events
{
    public interface IEventHub<EventType> where EventType : IEvent
    {
        ValueTask Raise(EventType eventTypeInstance);
    }
}
