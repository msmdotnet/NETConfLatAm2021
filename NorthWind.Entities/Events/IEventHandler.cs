namespace NorthWind.Entities.Events
{
    public interface IEventHandler<Eventype> where Eventype : IEvent
    {
        ValueTask Handle(Eventype eventTypeInstance);
    }
}
