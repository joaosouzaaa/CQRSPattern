using CQRSPattern.Application.Books.Commands.UpdateBook;
using UnitTests.TestBuilders;

namespace UnitTests.MappersTests.Books;

public sealed class UpdateBookMapperTests
{
    private readonly UpdateBookMapper _updateBookMapper;

    public UpdateBookMapperTests()
    {
        _updateBookMapper = new UpdateBookMapper();
    }

    [Fact]
    public void UpdateToDomain_SuccessfulScenario_MapsPropertiesSuccessfully()
    {
        // A
        var updateBookCommand = BookBuilder.NewObject().UpdateCommandBuild();
        var bookResult = BookBuilder.NewObject().DomainBuild();

        // A
        _updateBookMapper.UpdateToDomain(updateBookCommand, bookResult);

        // A
        Assert.Equal(bookResult.Title, updateBookCommand.Title);
        Assert.Equal(bookResult.Author, updateBookCommand.Author);
        Assert.Equal(bookResult.Gender, updateBookCommand.Gender);
        Assert.Equal(bookResult.PublicationDate, updateBookCommand.PublicationDate);
    }
}
