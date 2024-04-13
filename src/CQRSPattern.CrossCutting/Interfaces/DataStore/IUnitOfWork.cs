namespace CQRSPattern.CrossCutting.Interfaces.DataStore;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
