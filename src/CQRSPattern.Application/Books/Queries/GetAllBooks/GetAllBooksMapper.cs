using CQRSPattern.Domain.Entities;

namespace CQRSPattern.Application.Books.Queries.GetAllBooks;

public sealed class GetAllBooksMapper : IGetAllBooksMapper
{
    public IEnumerable<BookGetAllResponse> DomainEnumerableToGetAllResponseEnumerable(IEnumerable<Book> bookEnumerable) =>
        bookEnumerable.Select(DomainToGetAllResponse);

    private BookGetAllResponse DomainToGetAllResponse(Book book) =>
        new(book.Id,
            book.Title,
            book.Author,
            book.Gender,
            book.PublicationDate);
}
