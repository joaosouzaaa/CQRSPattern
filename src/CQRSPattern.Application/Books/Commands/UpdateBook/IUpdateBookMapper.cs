using CQRSPattern.Domain.Entities;

namespace CQRSPattern.Application.Books.Commands.UpdateBook;

public interface IUpdateBookMapper
{
    void UpdateToDomain(UpdateBookCommand updateBookCommand, Book book);
}
