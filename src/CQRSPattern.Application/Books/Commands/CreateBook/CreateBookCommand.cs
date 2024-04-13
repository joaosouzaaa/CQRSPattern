using CQRSPattern.Domain.Enums;
using MediatR;

namespace CQRSPattern.Application.Books.Commands.CreateBook;

public sealed record CreateBookCommand(
    string Title,
    string Author,
    EGender Gender,
    DateTime PublicationDate) 
    : IRequest;
