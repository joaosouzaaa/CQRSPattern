using CQRSPattern.Domain.Entities;

namespace CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories;

public interface IBookQueryRepository
{
    Task<Book?> GetByIdAsync(int id);
    Task<IEnumerable<Book>> GetAllAsync();
}
