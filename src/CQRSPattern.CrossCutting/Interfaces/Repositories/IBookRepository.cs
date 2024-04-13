using CQRSPattern.Domain.Entities;

namespace CQRSPattern.CrossCutting.Interfaces.Repositories;
public interface IBookRepository
{
    void Add(Book book);
    void Update(Book book);
    Task<bool> ExistsAsync(int id);    
    Task DeleteAsync(int id);
}
