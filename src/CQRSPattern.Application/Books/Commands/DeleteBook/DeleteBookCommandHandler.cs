using CQRSPattern.CrossCutting.Extensions;
using CQRSPattern.CrossCutting.Interfaces.DataLayer;
using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using CQRSPattern.CrossCutting.Interfaces.Settings;
using CQRSPattern.Domain.Entities;
using CQRSPattern.Domain.Enums;
using MediatR;

namespace CQRSPattern.Application.Books.Commands.DeleteBook;

public sealed class DeleteBookCommandHandler(
    IBookCommandRepository bookCommandRepository,
    IUnitOfWork unitOfWork,
    INotificationHandler notificationHandler) 
    : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        if(!await bookCommandRepository.ExistsAsync(request.Id))
        {
            notificationHandler.AddNotification(nameof(EMessage.NotFound), EMessage.NotFound.Description().FormatTo(nameof(Book)));

            return;
        }

        await bookCommandRepository.DeleteAsync(request.Id);

        await unitOfWork.SaveChangesAsync();
    }
}
