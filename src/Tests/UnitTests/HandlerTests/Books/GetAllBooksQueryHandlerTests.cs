using CQRSPattern.Application.Books.Queries.GetAllBooks;
using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using CQRSPattern.Domain.Entities;
using Moq;
using UnitTests.TestBuilders;

namespace UnitTests.HandlerTests.Books;

public sealed class GetAllBooksQueryHandlerTests
{
    private readonly Mock<IBookQueryRepository> _bookQueryRepositoryMock;
    private readonly Mock<IGetAllBooksMapper> _getAllBooksMapperMock;
    private readonly GetAllBooksQueryHandler _handler;

    public GetAllBooksQueryHandlerTests()
    {
        _bookQueryRepositoryMock = new Mock<IBookQueryRepository>();
        _getAllBooksMapperMock = new Mock<IGetAllBooksMapper>();
        _handler = new GetAllBooksQueryHandler(_bookQueryRepositoryMock.Object, _getAllBooksMapperMock.Object);
    }

    [Fact]
    public async Task Handle_SuccessfulScenario_ReturnsEntityList()
    {
        // A
        var getAllBooksQuery = BookBuilder.NewObject().AllQueryBuild();

        IEnumerable<Book> bookEnumerable =
        [
            BookBuilder.NewObject().DomainBuild(),
            BookBuilder.NewObject().DomainBuild(),
            BookBuilder.NewObject().DomainBuild()
        ];
        _bookQueryRepositoryMock.Setup(b => b.GetAllAsync())
            .ReturnsAsync(bookEnumerable);

        IEnumerable<BookGetAllResponse> bookGetAllResponseEnumerable =
        [
            BookBuilder.NewObject().GetAllResponseBuild()
        ];
        _getAllBooksMapperMock.Setup(g => g.DomainEnumerableToGetAllResponseEnumerable(It.IsAny<IEnumerable<Book>>()))
            .Returns(bookGetAllResponseEnumerable);

        // A
        var bookGetAllResponseEnumerableResult = await _handler.Handle(getAllBooksQuery, default);

        // A
        Assert.Equal(bookGetAllResponseEnumerableResult.Count(), bookGetAllResponseEnumerable.Count());
    }
}
