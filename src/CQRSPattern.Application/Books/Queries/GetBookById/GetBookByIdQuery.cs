using MediatR;

namespace CQRSPattern.Application.Books.Queries.GetBookById;

public sealed record GetBookByIdQuery(int Id) : IRequest<BookByIdResponse>;
