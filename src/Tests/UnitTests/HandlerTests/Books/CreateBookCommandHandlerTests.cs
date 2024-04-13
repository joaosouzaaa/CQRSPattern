using CQRSPattern.Application.Books.Commands.CreateBook;
using CQRSPattern.CrossCutting.Interfaces.DataLayer;
using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using CQRSPattern.CrossCutting.Interfaces.Settings;
using CQRSPattern.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using UnitTests.TestBuilders;

namespace UnitTests.HandlerTests.Books;

public sealed class CreateBookCommandHandlerTests
{
    private readonly Mock<IBookCommandRepository> _bookCommandRepositoryMock;
    private readonly Mock<ICreateBookMapper> _createBookMapperMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IValidator<Book>> _validatorMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly CreateBookCommandHandler _handler;

    public CreateBookCommandHandlerTests()
    {
        _bookCommandRepositoryMock = new Mock<IBookCommandRepository>();
        _createBookMapperMock = new Mock<ICreateBookMapper>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _validatorMock = new Mock<IValidator<Book>>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _handler = new CreateBookCommandHandler(_bookCommandRepositoryMock.Object, _createBookMapperMock.Object,
            _unitOfWorkMock.Object, _validatorMock.Object, _notificationHandlerMock.Object);
    }

    [Fact]
    public async Task Handle_SuccessfulScenario_ReturnsSuccessfulTask()
    {
        // A
        var createBookCommand = BookBuilder.NewObject().CreateCommandBuild();

        var book = BookBuilder.NewObject().DomainBuild();
        _createBookMapperMock.Setup(c => c.CreateToDomain(It.IsAny<CreateBookCommand>()))
            .Returns(book);

        var validationResult = new ValidationResult();
        _validatorMock.Setup(v => v.ValidateAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        _bookCommandRepositoryMock.Setup(b => b.Add(It.IsAny<Book>()));

        _unitOfWorkMock.Setup(u => u.SaveChangesAsync());

        // A
        await _handler.Handle(createBookCommand, default);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        _bookCommandRepositoryMock.Verify(b => b.Add(It.IsAny<Book>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once());
    }

    [Fact]
    public async Task Handle_InvalidEntity_ReturnsUnsuccessfulTask()
    {
        // A
        var createBookCommand = BookBuilder.NewObject().CreateCommandBuild();

        var book = BookBuilder.NewObject().DomainBuild();
        _createBookMapperMock.Setup(c => c.CreateToDomain(It.IsAny<CreateBookCommand>()))
            .Returns(book);

        var validationFailureList = new List<ValidationFailure>()
        {
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
        await _handler.Handle(createBookCommand, default);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(validationResult.Errors.Count)); ;
        _bookCommandRepositoryMock.Verify(b => b.Add(It.IsAny<Book>()), Times.Never());
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Never());
    }
}
