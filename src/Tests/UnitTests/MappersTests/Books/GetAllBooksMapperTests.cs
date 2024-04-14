using CQRSPattern.Application.Books.Queries.GetAllBooks;
using CQRSPattern.Domain.Entities;
using UnitTests.TestBuilders;

namespace UnitTests.MappersTests.Books;

public sealed class GetAllBooksMapperTests
{
    private readonly GetAllBooksMapper _getAllBooksMapper;

    public GetAllBooksMapperTests()
    {
        _getAllBooksMapper = new GetAllBooksMapper();
    }

    [Fact]
    public void DomainEnumerableToGetAllResponseEnumerable_SuccessfulScenario_ReturnsEntityList()
    {
        // A
        IEnumerable<Book> bookEnumerable =
        [
            BookBuilder.NewObject().DomainBuild(),
            BookBuilder.NewObject().DomainBuild(),
            BookBuilder.NewObject().DomainBuild()
        ];

        // A
        var bookGetAllResponseEnumerableResult = _getAllBooksMapper.DomainEnumerableToGetAllResponseEnumerable(bookEnumerable);

        // A
        Assert.Equal(bookGetAllResponseEnumerableResult.Count(), bookEnumerable.Count());
    }
}
