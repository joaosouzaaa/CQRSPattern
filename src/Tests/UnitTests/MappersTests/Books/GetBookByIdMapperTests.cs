using CQRSPattern.Application.Books.Queries.GetBookById;
using UnitTests.TestBuilders;

namespace UnitTests.MappersTests.Books;

public sealed class GetBookByIdMapperTests
{
    private readonly GetBookByIdMapper _getBookByIdMapper;

    public GetBookByIdMapperTests()
    {
        _getBookByIdMapper = new GetBookByIdMapper();
    }

    [Fact]
    public void DomainToByIdResponse_SuccessfulScenario_ReturnsResponseEntity()
    {
        // A
        var book = BookBuilder.NewObject().DomainBuild();

        // A
        var bookByIdResponseResult = _getBookByIdMapper.DomainToByIdResponse(book);

        // A
        Assert.Equal(bookByIdResponseResult.Id, book.Id);
        Assert.Equal(bookByIdResponseResult.Title, book.Title);
        Assert.Equal(bookByIdResponseResult.Author, book.Author);
        Assert.Equal(bookByIdResponseResult.Gender, book.Gender);
        Assert.Equal(bookByIdResponseResult.PublicationDate, book.PublicationDate);
    }
}
