using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories;
using CQRSPattern.DatabaseSettings.DatabaseContexts;
using CQRSPattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSPattern.DataStore.Repositories;

public sealed class BookRepository(AppDbContext dbContext) : IBookRepository, IDisposable
{
    private DbSet<Book> DbContextSet => dbContext.Set<Book>();

    public void Add(Book book) =>
        DbContextSet.Add(book);

    public void Update(Book book) =>
        dbContext.Entry(book).State = EntityState.Modified; 

    public Task<bool> ExistsAsync(int id) =>
        DbContextSet.AsNoTracking().AnyAsync(b => b.Id == id);

    public async Task DeleteAsync(int id)
    {
        var book = await DbContextSet.FindAsync(id);

        DbContextSet.Remove(book!);
    }

    public void Dispose()
    {
        dbContext.Dispose();
        
        GC.SuppressFinalize(this);
    }
}
