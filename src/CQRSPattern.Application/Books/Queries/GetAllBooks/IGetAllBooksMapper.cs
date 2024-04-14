using CQRSPattern.Domain.Entities;

namespace CQRSPattern.Application.Books.Queries.GetAllBooks;

public interface IGetAllBooksMapper
{
    IEnumerable<BookGetAllResponse> DomainEnumerableToGetAllResponseEnumerable(IEnumerable<Book> bookEnumerable);
}
