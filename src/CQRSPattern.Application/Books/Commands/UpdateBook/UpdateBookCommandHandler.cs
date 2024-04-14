using CQRSPattern.Application.BaseHandlers;
using CQRSPattern.CrossCutting.Extensions;
using CQRSPattern.CrossCutting.Interfaces.DataLayer;
using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using CQRSPattern.CrossCutting.Interfaces.Settings;
using CQRSPattern.Domain.Entities;
using CQRSPattern.Domain.Enums;
using FluentValidation;
using MediatR;

namespace CQRSPattern.Application.Books.Commands.UpdateBook;

public sealed class UpdateBookCommandHandler : BaseCommandHandler<Book>, IRequestHandler<UpdateBookCommand>
{
    private readonly IBookCommandRepository _bookCommandRepository;
    private readonly IUpdateBookMapper _updateBookMapper;

    public UpdateBookCommandHandler(
        IBookCommandRepository bookCommandRepository,
        IUpdateBookMapper updateBookMapper,
        IUnitOfWork unitOfWork,
        IValidator<Book> validator,
        INotificationHandler notificationHandler)
        : base(
            unitOfWork,
            validator,
            notificationHandler)
    {
        _bookCommandRepository = bookCommandRepository;
        _updateBookMapper = updateBookMapper;
    }

    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookCommandRepository.GetByIdAsync(request.Id);

        if (book is null)
        {
            _notificationHandler.AddNotification(nameof(EMessage.NotFound), EMessage.NotFound.Description().FormatTo(nameof(Book)));

            return;
        }

        _updateBookMapper.UpdateToDomain(request, book);

        if (!await ValidateAsync(book))
        {
            return;
        }

        _bookCommandRepository.Update(book);

        await _unitOfWork.SaveChangesAsync();
    }
}
