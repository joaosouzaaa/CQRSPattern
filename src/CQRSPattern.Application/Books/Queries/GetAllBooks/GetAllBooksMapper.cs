using CQRSPattern.Domain.Entities;

namespace CQRSPattern.Application.Books.Queries.GetAllBooks;

public sealed class GetAllBooksMapper
{
    public IEnumerable<BookGetAllResponse> DomainListToGetAllResponseList(List<Book> bookList) =>
        bookList.Select(DomainToGetAllResponse);

    private BookGetAllResponse DomainToGetAllResponse(Book book) =>
        new(book.Id,
            book.Title,
            book.Author,
            book.Gender,
            book.PublicationDate);
}
