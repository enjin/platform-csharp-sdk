using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class PusherEventServiceBuilderTest
{
    private PusherEventService.PusherEventServiceBuilder ClassUnderTest { get; set; }

    [SetUp]
    public void SetUp()
    {
        ClassUnderTest = new PusherEventService.PusherEventServiceBuilder();
    }

    [Test]
    public void BuildWhenKeyIsSetReturnsEventServiceInstance()
    {
        // Arrange
        ClassUnderTest.SetKey("Dummy Key");

        // Act
        PusherEventService service = ClassUnderTest.Build();

        // Assert
        Assert.That(service, Is.Not.Null);
    }

    [Test]
    public void BuildWhenKeyIsNotSetThrowsInvalidOperationException()
    {
        // Assert
        Assert.Throws<InvalidOperationException>(() => ClassUnderTest.Build());
    }

    [Test]
    public void BuildWhenKeyAndClusterAreSetReturnsEventServiceInstance()
    {
        // Arrange
        ClassUnderTest.SetKey("Dummy Key");
        ClassUnderTest.SetCluster("Dummy Cluster");

        // Act
        PusherEventService service = ClassUnderTest.Build();

        // Assert
        Assert.That(service, Is.Not.Null);
    }

    [Test]
    public void BuildWhenKeyAndHostAreSetReturnsEventServiceInstance()
    {
        // Arrange
        ClassUnderTest.SetKey("Dummy Key");
        ClassUnderTest.SetHost("Dummy Host");

        // Act
        PusherEventService service = ClassUnderTest.Build();

        // Assert
        Assert.That(service, Is.Not.Null);
    }

    [Test]
    public void BuildWhenKeyAndClusterAndHostAreSetThrowsInvalidOperationException()
    {
        // Arrange
        ClassUnderTest.SetKey("Dummy Key");
        ClassUnderTest.SetCluster("Dummy Cluster");
        ClassUnderTest.SetHost("Dummy Host");

        // Assert
        Assert.Throws<InvalidOperationException>(() => ClassUnderTest.Build());
    }
}