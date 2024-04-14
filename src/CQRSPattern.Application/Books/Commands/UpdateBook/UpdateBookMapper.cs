using CQRSPattern.Domain.Entities;

namespace CQRSPattern.Application.Books.Commands.UpdateBook;

public sealed class UpdateBookMapper : IUpdateBookMapper
{
    public void UpdateToDomain(UpdateBookCommand updateBookCommand, Book book)
    {
        book.Title = updateBookCommand.Title;
        book.Author = updateBookCommand.Author;
        book.Gender = updateBookCommand.Gender;
        book.PublicationDate = updateBookCommand.PublicationDate;
    }
}
