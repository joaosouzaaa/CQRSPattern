using CQRSPattern.Domain.Enums;

namespace CQRSPattern.Application.Books.Commands.CreateBook;

public sealed record CreateBookCommand(
    string Title,
    string Author,
    EGender Gender,
    DateTime PublicationDate);
