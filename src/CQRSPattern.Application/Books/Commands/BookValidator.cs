using CQRSPattern.CrossCutting.Extensions;
using CQRSPattern.Domain.Entities;
using CQRSPattern.Domain.Enums;
using FluentValidation;

namespace CQRSPattern.Application.Books.Commands;

public sealed class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(b => b.Title).Length(3, 150)
            .WithMessage(EMessage.InvalidLength.Description().FormatTo(nameof(Book.Title), "3 to 150"));

        RuleFor(b => b.Author).Length(3, 100)
            .WithMessage(EMessage.InvalidLength.Description().FormatTo(nameof(Book.Author), "3 to 100"));
    }
}
