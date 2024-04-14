using CQRSPattern.Application.Books.Commands.CreateBook;
using CQRSPattern.Application.Books.Commands.DeleteBook;
using CQRSPattern.Application.Books.Commands.UpdateBook;
using CQRSPattern.Application.Books.Queries.GetAllBooks;
using CQRSPattern.Application.Books.Queries.GetBookById;
using CQRSPattern.Domain.Entities;
using CQRSPattern.Domain.Enums;

namespace UnitTests.TestBuilders;

internal sealed class BookBuilder
{
    private readonly int _id = 123;
    private string _title = "random";
    private string _author = "test";
    private readonly EGender _gender = EGender.Fiction;
    private readonly DateTime _publicationDate = DateTime.Now;

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

    public UpdateBookCommand UpdateCommandBuild() =>
        new(_id,
            _title,
            _author,
            _gender,
            _publicationDate);

    public DeleteBookCommand DeleteCommandBuild() =>
        new(_id);

    public GetBookByIdQuery ByIdQueryBuild() =>
        new(_id);

    public BookByIdResponse ByIdResponseBuild() =>
        new(_id,
            _title,
            _author,
            _gender,
            _publicationDate);

    public GetAllBooksQuery AllQueryBuild() =>
        new();

    public BookGetAllResponse GetAllResponseBuild() =>
        new(_id,
            _title,
            _author,
            _gender,
            _publicationDate);

    public BookBuilder WithTitle(string title)
    {
        _title = title;

        return this;
    }

    public BookBuilder WithAuthor(string author)
    {
        _author = author;

        return this;
    }
}
