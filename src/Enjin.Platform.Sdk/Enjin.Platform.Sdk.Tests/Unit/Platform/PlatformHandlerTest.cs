using Moq;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class PlatformHandlerTest
{
    private PlatformHandler ClassUnderTest { get; set; }

    [SetUp]
    public void SetUp()
    {
        HttpMessageHandler dummyInnerHandler = Mock.Of<HttpMessageHandler>();
        ClassUnderTest = new PlatformHandler(dummyInnerHandler);
    }

    [Test]
    public void HasAuthTokenWhenNoTokenIsSetReturnsFalse()
    {
        // Act
        bool actual = ClassUnderTest.HasAuthToken;

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void SetAuthTokenWhenGivenEmptyTokenDoesNotHaveAuthToken()
    {
        // Arrange
        string token = string.Empty;

        // Act
        ClassUnderTest.SetAuthToken(token);

        // Assert
        Assert.That(ClassUnderTest.HasAuthToken, Is.False);
    }

    [Test]
    public void SetAuthTokenWhenGivenPopulatedTokenDoesHaveAuthToken()
    {
        // Arrange
        const string token = "xyz";

        // Act
        ClassUnderTest.SetAuthToken(token);

        // Assert
        Assert.That(ClassUnderTest.HasAuthToken, Is.True);
    }
}