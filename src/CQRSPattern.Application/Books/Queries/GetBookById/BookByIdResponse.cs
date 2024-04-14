using CQRSPattern.Domain.Enums;

namespace CQRSPattern.Application.Books.Queries.GetBookById;

public sealed record BookByIdResponse(int Id,
    string Title,
    string Author,
    EGender Gender,
    DateTime PublicationDate);
