using CQRSPattern.Application.Books.Queries.GetBookById;
using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using CQRSPattern.Domain.Entities;
using Moq;
using UnitTests.TestBuilders;

namespace UnitTests.HandlerTests.Books;

public sealed class GetBookByIdQueryHandlerTests
{
    private readonly Mock<IBookQueryRepository> _bookQueryRepositoryMock;
    private readonly Mock<IGetBookByIdMapper> _getBookByIdMapperMock;
    private readonly GetBookByIdQueryHandler _handler;

    public GetBookByIdQueryHandlerTests()
    {
        _bookQueryRepositoryMock = new Mock<IBookQueryRepository>();
        _getBookByIdMapperMock = new Mock<IGetBookByIdMapper>();
        _handler = new GetBookByIdQueryHandler(_bookQueryRepositoryMock.Object, _getBookByIdMapperMock.Object);
    }

    [Fact]
    public async Task Handle_SuccessfulScenario_ReturnsEntity()
    {
        // A
        var getBookByIdQuery = BookBuilder.NewObject().ByIdQueryBuild();

        var book = BookBuilder.NewObject().DomainBuild();
        _bookQueryRepositoryMock.Setup(b => b.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(book);

        var bookByIdResponse = BookBuilder.NewObject().ByIdResponseBuild();
        _getBookByIdMapperMock.Setup(g => g.DomainToByIdResponse(It.IsAny<Book>()))
            .Returns(bookByIdResponse);

        // A
        var bookByIdResponseResult = await _handler.Handle(getBookByIdQuery, default);

        // A
        _getBookByIdMapperMock.Verify(g => g.DomainToByIdResponse(It.IsAny<Book>()), Times.Once());

        Assert.NotNull(bookByIdResponseResult);
    }

    [Fact]
    public async Task Handle_EntityDoesNotExist_ReturnsNull()
    {
        // A
        var getBookByIdQuery = BookBuilder.NewObject().ByIdQueryBuild();

        _bookQueryRepositoryMock.Setup(b => b.GetByIdAsync(It.IsAny<int>()))
            .Returns(Task.FromResult<Book?>(null));

        // A
        var bookByIdResponseResult = await _handler.Handle(getBookByIdQuery, default);

        // A
        _getBookByIdMapperMock.Verify(g => g.DomainToByIdResponse(It.IsAny<Book>()), Times.Never());

        Assert.Null(bookByIdResponseResult);
    }
}
