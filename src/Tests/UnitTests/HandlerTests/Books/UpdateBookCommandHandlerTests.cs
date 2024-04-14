using CQRSPattern.Application.Books.Commands.UpdateBook;
using CQRSPattern.CrossCutting.Interfaces.DataLayer;
using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using CQRSPattern.CrossCutting.Interfaces.Settings;
using CQRSPattern.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using UnitTests.TestBuilders;

namespace UnitTests.HandlerTests.Books;

public sealed class UpdateBookCommandHandlerTests
{
    private readonly Mock<IBookCommandRepository> _bookCommandRepositoryMock;
    private readonly Mock<IUpdateBookMapper> _updateBookMapperMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IValidator<Book>> _validatorMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly UpdateBookCommandHandler _handler;

    public UpdateBookCommandHandlerTests()
    {
        _bookCommandRepositoryMock = new Mock<IBookCommandRepository>();
        _updateBookMapperMock = new Mock<IUpdateBookMapper>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _validatorMock = new Mock<IValidator<Book>>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _handler = new UpdateBookCommandHandler(_bookCommandRepositoryMock.Object, _updateBookMapperMock.Object,
            _unitOfWorkMock.Object, _validatorMock.Object, _notificationHandlerMock.Object);
    }

    [Fact]
    public async Task Handle_SuccessfulScenario_ReturnsSuccessfulTask()
    {
        // A
        var updateBookCommand = BookBuilder.NewObject().UpdateCommandBuild();

        var book = BookBuilder.NewObject().DomainBuild();

        _bookCommandRepositoryMock.Setup(b => b.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(book);

        _updateBookMapperMock.Setup(u => u.UpdateToDomain(It.IsAny<UpdateBookCommand>(), It.IsAny<Book>()));

        var validationResult = new ValidationResult();
        _validatorMock.Setup(v => v.ValidateAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        _bookCommandRepositoryMock.Setup(b => b.Update(It.IsAny<Book>()));

        _unitOfWorkMock.Setup(u => u.SaveChangesAsync());

        // A
        await _handler.Handle(updateBookCommand, default);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        _bookCommandRepositoryMock.Verify(b => b.Update(It.IsAny<Book>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once());
    }

    [Fact]
    public async Task Handle_EntityDoesNotExist_ReturnsUnsuccessfulTask()
    {
        // A
        var updateBookCommand = BookBuilder.NewObject().UpdateCommandBuild();

        _bookCommandRepositoryMock.Setup(b => b.GetByIdAsync(It.IsAny<int>()))
            .Returns(Task.FromResult<Book?>(null));

        // A
        await _handler.Handle(updateBookCommand, default);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        _updateBookMapperMock.Verify(u => u.UpdateToDomain(It.IsAny<UpdateBookCommand>(), It.IsAny<Book>()), Times.Never());
        _validatorMock.Verify(v => v.ValidateAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()), Times.Never());
        _bookCommandRepositoryMock.Verify(b => b.Update(It.IsAny<Book>()), Times.Never());
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Never());
    }

    [Fact]
    public async Task Handle_EntityInvalid_ReturnsUnsuccessfulTask()
    {
        // A
        var updateBookCommand = BookBuilder.NewObject().UpdateCommandBuild();

        var book = BookBuilder.NewObject().DomainBuild();

        _bookCommandRepositoryMock.Setup(b => b.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(book);

        _updateBookMapperMock.Setup(u => u.UpdateToDomain(It.IsAny<UpdateBookCommand>(), It.IsAny<Book>()));

        var validationFailureList = new List<ValidationFailure>()
        {
            new("tes", "random"),
            new("tes", "random"),
            new("tes", "random"),
            new("tes", "random"),
            new("tes", "random")
        };
        var validationResult = new ValidationResult()
        {
            Errors = validationFailureList
        };
        _validatorMock.Setup(v => v.ValidateAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        // A
        await _handler.Handle(updateBookCommand, default);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(validationResult.Errors.Count)); ;
        _bookCommandRepositoryMock.Verify(b => b.Update(It.IsAny<Book>()), Times.Never());
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Never());
    }
}
