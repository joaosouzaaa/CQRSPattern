using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using MediatR;

namespace CQRSPattern.Application.Books.Queries.GetBookById;

public sealed class GetBookByIdQueryHandler(
    IBookQueryRepository bookQueryRepository,
    IGetBookByIdMapper getBookByIdMapper) 
    : IRequestHandler<GetBookByIdQuery, BookByIdResponse?>
{
    public async Task<BookByIdResponse?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await bookQueryRepository.GetByIdAsync(request.Id);

        if (book is null)
            return null;

        return getBookByIdMapper.DomainToByIdResponse(book);
    }
}
