namespace NorthWind.Entities.Events
{
    public class EventHub<EventType> : IEventHub<EventType> where EventType : IEvent
    {
        readonly IEnumerable<IEventHandler<EventType>> EventHandlers;
        public EventHub(IEnumerable<IEventHandler<EventType>> eventHandlers) =>
            EventHandlers = eventHandlers;
        public async ValueTask Raise(EventType eventTypeInstance)
        {
            foreach (var Handler in EventHandlers)
            {
                await Handler.Handle(eventTypeInstance);
            }
        }
    }
}
