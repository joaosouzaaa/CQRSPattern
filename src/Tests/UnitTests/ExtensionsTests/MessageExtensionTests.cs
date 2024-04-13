using CQRSPattern.CrossCutting.Extensions;
using CQRSPattern.Domain.Enums;

namespace UnitTests.ExtensionsTests;

public sealed class MessageExtensionTests
{
    [Fact]
    public void Description_Equals_AsIntended()
    {
        // A
        var messageToGetDescription = EMessage.InvalidLength;

        // A
        var messageDescription = messageToGetDescription.Description();

        // A
        Assert.Equal("{0} has invalid length. It should be {1}.", messageDescription);
    }
}
