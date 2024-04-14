using CQRSPattern.Domain.Enums;

namespace CQRSPattern.Application.Books.Queries.GetAllBooks;

public sealed record BookGetAllResponse(
    int Id,
    string Title,
    string Author,
    EGender Gender,
    DateTime PublicationDate);
