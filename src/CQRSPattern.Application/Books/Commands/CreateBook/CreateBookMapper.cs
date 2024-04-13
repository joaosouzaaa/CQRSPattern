using CQRSPattern.Domain.Entities;

namespace CQRSPattern.Application.Books.Commands.CreateBook;

public sealed class CreateBookMapper : ICreateBookMapper
{
    public Book CreateToDomain(Book book) =>
        new()
        {
            Title = book.Title,
            Author = book.Author,
            Gender = book.Gender,
            PublicationDate = book.PublicationDate
        };
}
