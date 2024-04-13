namespace CQRSPattern.CrossCutting.Interfaces.DataLayer;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
