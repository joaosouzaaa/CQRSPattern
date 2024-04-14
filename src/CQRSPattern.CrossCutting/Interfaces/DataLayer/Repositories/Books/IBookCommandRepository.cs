using CQRSPattern.Domain.Entities;

namespace CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;

public interface IBookCommandRepository
{
    void Add(Book book);
    Task<Book?> GetByIdAsync(int id);
    void Update(Book book);
    Task<bool> ExistsAsync(int id);
    Task DeleteAsync(int id);
}
