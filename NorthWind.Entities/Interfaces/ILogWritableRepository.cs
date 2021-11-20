namespace NorthWind.Entities.Interfaces
{
    public interface ILogWritableRepository
    {
        void Add(Log log);
        void Add(string description);
    }
}
