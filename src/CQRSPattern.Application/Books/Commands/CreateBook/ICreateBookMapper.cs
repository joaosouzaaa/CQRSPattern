using CQRSPattern.Domain.Entities;

namespace CQRSPattern.Application.Books.Commands.CreateBook;

public interface ICreateBookMapper
{
    Book CreateToDomain(CreateBookCommand createBookCommand);
}
