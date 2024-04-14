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
        Assert.Equal(bookResult.Title, createBookCommand.Title);
        Assert.Equal(bookResult.Author, createBookCommand.Author);
        Assert.Equal(bookResult.Gender, createBookCommand.Gender);
        Assert.Equal(bookResult.PublicationDate, createBookCommand.PublicationDate);
    }
}
