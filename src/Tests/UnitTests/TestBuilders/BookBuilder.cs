using CQRSPattern.Application.Books.Commands.CreateBook;
using CQRSPattern.Domain.Entities;
using CQRSPattern.Domain.Enums;

namespace UnitTests.TestBuilders;

internal sealed class BookBuilder
{
    private readonly int _id = 123;
    private string _title = "random";
    private string _author = "test";
    private readonly EGender _gender = EGender.Fiction;
    private DateTime _publicationDate = DateTime.Now;

    public static BookBuilder NewObject() =>
        new();

    public Book DomainBuild() =>
        new()
        {
            Author = _author,
            Gender = _gender,
            Id = _id,
            PublicationDate = _publicationDate,
            Title = _title
        };

    public CreateBookCommand CreateCommandBuild() =>
        new(_title,
            _author,
            _gender,
            _publicationDate);
}
