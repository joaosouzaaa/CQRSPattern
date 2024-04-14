using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using MediatR;

namespace CQRSPattern.Application.Books.Queries.GetAllBooks;

public sealed class GetAllBooksQueryHandler(
    IBookQueryRepository bookQueryRepository,
    IGetAllBooksMapper getAllBooksMapper) 
    : IRequestHandler<GetAllBooksQuery, IEnumerable<BookGetAllResponse>>
{
    public async Task<IEnumerable<BookGetAllResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var bookEnumerable = await bookQueryRepository.GetAllAsync();

        return getAllBooksMapper.DomainEnumerableToGetAllResponseEnumerable(bookEnumerable);
    }
}
