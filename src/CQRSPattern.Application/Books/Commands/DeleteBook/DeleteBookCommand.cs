using MediatR;

namespace CQRSPattern.Application.Books.Commands.DeleteBook;

public sealed record DeleteBookCommand(int Id) : IRequest;
