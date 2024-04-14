using CQRSPattern.Application.Books.Commands.DeleteBook;
using CQRSPattern.CrossCutting.Interfaces.DataLayer;
using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using CQRSPattern.CrossCutting.Interfaces.Settings;
using Moq;
using UnitTests.TestBuilders;

namespace UnitTests.HandlerTests.Books;

public sealed class DeleteBookCommandHandlerTests
{
    private readonly Mock<IBookCommandRepository> _bookCommandRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly DeleteBookCommandHandler _handler;

    public DeleteBookCommandHandlerTests()
    {
        _bookCommandRepositoryMock = new Mock<IBookCommandRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _handler = new DeleteBookCommandHandler(_bookCommandRepositoryMock.Object, _unitOfWorkMock.Object, 
            _notificationHandlerMock.Object);
    }

    [Fact]
    public async Task Handle_SuccessfulScenario_ReturnsSuccessfulTask()
    {
        // A
        var deleteBookCommand = BookBuilder.NewObject().DeleteCommandBuild();

        _bookCommandRepositoryMock.Setup(b => b.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        _bookCommandRepositoryMock.Setup(b => b.DeleteAsync(It.IsAny<int>()));

        _unitOfWorkMock.Setup(u => u.SaveChangesAsync());

        // A
        await _handler.Handle(deleteBookCommand, default);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        _bookCommandRepositoryMock.Verify(b => b.DeleteAsync(It.IsAny<int>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once());
    }

    [Fact]
    public async Task Handle_EntityDoesNotExist_ReturnsUnsuccessfulTask()
    {
        // A
        var deleteBookCommand = BookBuilder.NewObject().DeleteCommandBuild();

        _bookCommandRepositoryMock.Setup(b => b.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        // A
        await _handler.Handle(deleteBookCommand, default);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        _bookCommandRepositoryMock.Verify(b => b.DeleteAsync(It.IsAny<int>()), Times.Never());
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Never());
    }
}
