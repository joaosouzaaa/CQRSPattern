using CQRSPattern.Domain.Entities;

namespace CQRSPattern.Application.Books.Queries.GetBookById;

public sealed class GetBookByIdMapper : IGetBookByIdMapper
{
    public BookByIdResponse DomainToByIdResponse(Book book) =>
        new(book.Id,
            book.Title,
            book.Author,
            book.Gender,
            book.PublicationDate);
}
