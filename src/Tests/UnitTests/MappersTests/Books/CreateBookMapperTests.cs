using CQRSPattern.Application.Books.Commands.CreateBook;
using UnitTests.TestBuilders;

namespace UnitTests.MappersTests.Books;

public sealed class CreateBookMapperTests
{
    private readonly CreateBookMapper _createBookMapper;

    public CreateBookMapperTests()
    {
        _createBookMapper = new CreateBookMapper();
    }

    [Fact]
    public void CreateToDomain_SuccessfulScenario_ReturnsDomainObject()
    {
        // A
        var createBookCommand = BookBuilder.NewObject().CreateCommandBuild();

        // A
        var bookResult = _createBookMapper.CreateToDomain(createBookCommand);

        // A
        Assert.Equal(createBookCommand.Title, bookResult.Title);
        Assert.Equal(createBookCommand.Author, bookResult.Author);
        Assert.Equal(createBookCommand.Gender, bookResult.Gender);
        Assert.Equal(createBookCommand.PublicationDate, bookResult.PublicationDate);
    }
}
