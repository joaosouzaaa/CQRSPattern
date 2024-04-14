using MediatR;

namespace CQRSPattern.Application.Books.Queries.GetAllBooks;

public sealed record GetAllBooksQuery : IRequest<IEnumerable<BookGetAllResponse>>;
