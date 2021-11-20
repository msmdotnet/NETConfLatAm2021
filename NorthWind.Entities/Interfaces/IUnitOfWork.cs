namespace NorthWind.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        ValueTask<int> SaveChanges();
    }
}
