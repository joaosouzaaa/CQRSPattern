using CQRSPattern.Domain.Entities;

namespace CQRSPattern.Application.Books.Queries.GetBookById;

public interface IGetBookByIdMapper
{
    BookByIdResponse DomainToByIdResponse(Book book);
}
