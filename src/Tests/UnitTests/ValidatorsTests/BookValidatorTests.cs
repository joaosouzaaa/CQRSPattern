using CQRSPattern.Application.Books.Commands;
using UnitTests.TestBuilders;

namespace UnitTests.ValidatorsTests;

public sealed class BookValidatorTests
{
    private readonly BookValidator _validator;

    public BookValidatorTests()
    {
        _validator = new BookValidator();
    }

    [Fact]
    public async Task ValidateAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var bookToValidate = BookBuilder.NewObject().DomainBuild();

        // A
        var validationResult = await _validator.ValidateAsync(bookToValidate);

        // A
        Assert.True(validationResult.IsValid);
    }

    [Theory]
    [MemberData(nameof(InvalidTitleParameters))]
    public async Task ValidateAsync_InvalidTitle_ReturnsFalse(string title)
    {
        // A
        var bookWithInvalidTitle = BookBuilder.NewObject().WithTitle(title).DomainBuild();

        // A
        var validationResult = await _validator.ValidateAsync(bookWithInvalidTitle);

        // A
        Assert.False(validationResult.IsValid);
    }

    public static TheoryData<string> InvalidTitleParameters() =>
        new()
        {
            "",
            "a",
            new string('a', 151)
        };

    [Theory]
    [MemberData(nameof(InvalidAuthorParameters))]
    public async Task ValidateAsync_InvalidAuthor_ReturnsFalse(string author)
    {
        // A
        var bookWithInvalidAuthor = BookBuilder.NewObject().WithAuthor(author).DomainBuild();

        // A
        var validationResult = await _validator.ValidateAsync(bookWithInvalidAuthor);

        // A
        Assert.False(validationResult.IsValid);
    }

    public static TheoryData<string> InvalidAuthorParameters() =>
        new()
        {
            "",
            "a",
            new string('a', 101)
        };
}
