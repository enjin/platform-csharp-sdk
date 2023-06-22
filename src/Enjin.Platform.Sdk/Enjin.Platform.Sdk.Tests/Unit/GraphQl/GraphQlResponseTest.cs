using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class GraphQlResponseTest
{
    [Test]
    public void IsEmptyWhenResultIsNullReturnsTrue()
    {
        // Arrange
        GraphQlData<bool?> data = new(null);
        GraphQlResponse<bool?> response = new(data, null);

        // Act
        bool actual = response.IsEmpty;

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void IsEmptyWhenResultIsNotNullReturnsFalse()
    {
        // Arrange
        GraphQlData<bool?> data = new(true);
        GraphQlResponse<bool?> response = new(data, null);

        // Act
        bool actual = response.IsEmpty;

        // Assert
        Assert.That(actual, Is.False);
    }
}