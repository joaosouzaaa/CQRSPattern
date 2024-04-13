using CQRSPattern.Domain.Entities;

namespace CQRSPattern.Application.Books.Commands.CreateBook;

public sealed class CreateBookMapper : ICreateBookMapper
{
    public Book CreateToDomain(CreateBookCommand createBookCommand) =>
        new()
        {
            Title = createBookCommand.Title,
            Author = createBookCommand.Author,
            Gender = createBookCommand.Gender,
            PublicationDate = createBookCommand.PublicationDate
        };
}
