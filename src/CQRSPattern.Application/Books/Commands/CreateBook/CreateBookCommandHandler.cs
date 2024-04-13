using CQRSPattern.Application.BaseHandlers;
using CQRSPattern.CrossCutting.Interfaces.DataLayer;
using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using CQRSPattern.CrossCutting.Interfaces.Settings;
using CQRSPattern.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CQRSPattern.Application.Books.Commands.CreateBook;

public sealed class CreateBookCommandHandler : BaseCommandHandler<Book>, IRequestHandler<CreateBookCommand>
{
    private readonly IBookCommandRepository _bookCommandRepository;
    private readonly ICreateBookMapper _createBookMapper;

    public CreateBookCommandHandler(
        IBookCommandRepository bookCommandRepository, 
        ICreateBookMapper createBookMapper,
        IUnitOfWork unitOfWork, 
        IValidator<Book> validator, 
        INotificationHandler notificationHandler) 
        : base(
            unitOfWork, 
            validator, 
            notificationHandler)
    {
        _bookCommandRepository = bookCommandRepository;
        _createBookMapper = createBookMapper;
    }

    public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _createBookMapper.CreateToDomain(request);

        if(!await ValidateAsync(book))
        {
            return;
        }

        _bookCommandRepository.Add(book);

        await _unitOfWork.SaveChangesAsync();
    }
}
