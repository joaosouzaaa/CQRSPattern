using CQRSPattern.Domain.Enums;
using MediatR;

namespace CQRSPattern.Application.Books.Commands.UpdateBook;

public sealed record UpdateBookCommand(
    int Id,
    string Title,
    string Author,
    EGender Gender,
    DateTime PublicationDate)
    : IRequest;
