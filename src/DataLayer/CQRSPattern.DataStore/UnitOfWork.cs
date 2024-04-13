using CQRSPattern.CrossCutting.Interfaces.DataStore;
using CQRSPattern.DatabaseSettings.DatabaseContexts;

namespace CQRSPattern.DataStore;

public sealed class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public Task SaveChangesAsync() =>
        dbContext.SaveChangesAsync();
}
