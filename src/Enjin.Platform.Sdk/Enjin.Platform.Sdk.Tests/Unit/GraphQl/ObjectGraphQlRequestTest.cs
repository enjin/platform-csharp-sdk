using Moq;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

public class ObjectGraphQlRequestImpl : GraphQlRequest<ObjectGraphQlRequestImpl, IGraphQlFragment>
{
    public ObjectGraphQlRequestImpl() : base("Request", GraphQlRequestType.Query)
    {
    }
}

[TestFixture]
public class ObjectGraphQlRequestTest
{
    private ObjectGraphQlRequestImpl ClassUnderTest { get; set; }

    // Mocks
    private Mock<IGraphQlFragment> MockFragment { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        MockFragment = new Mock<IGraphQlFragment>();
    }

    [SetUp]
    public void BeforeEach()
    {
        MockFragment.Reset();

        ClassUnderTest = new ObjectGraphQlRequestImpl();
    }

    [Test]
    public void CompileWhenNoFragmentIsSetThrowsInvalidOperationException()
    {
        // Assumptions
        Assume.That(ClassUnderTest.HasFragment, Is.False,
                    $"Assume {nameof(ClassUnderTest.HasFragment)} is false");

        // Assert
        Assert.Throws<InvalidOperationException>(() => ClassUnderTest.Compile());
    }

    [Test]
    public void CompileWhenVariablesAreNotSetOnRequestAndParametersAreNotSetOnFragmentReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"query { result: Request { field } }";
        ClassUnderTest.Fragment(MockFragment.Object);

        // Arrange - Stubbing
        MockFragment.Setup(mock => mock.CompileFields())
                    .Returns(@"field")
                    .Verifiable($"Verify call to {nameof(MockFragment.Object.CompileFields)} on ${nameof(MockFragment)}");
        MockFragment.Setup(mock => mock.HasParameters)
                    .Returns(false)
                    .Verifiable($"Verify call to {nameof(MockFragment.Object.HasParameters)} on ${nameof(MockFragment)}");

        // Act
        string actual = ClassUnderTest.Compile();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockFragment.Verify();
    }

    [Test]
    public void CompileWhenVariablesAreNotSetOnRequestAndParametersAreSetOnFragmentReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"query { result: Request(key: ""value"") { field } }";
        ClassUnderTest.Fragment(MockFragment.Object);

        // Arrange - Stubbing
        MockFragment.Setup(mock => mock.CompileFields())
                    .Returns(@"field")
                    .Verifiable($"Verify call to {nameof(MockFragment.Object.CompileFields)} on ${nameof(MockFragment)}");
        MockFragment.Setup(mock => mock.CompileParameters())
                    .Returns(@"key: ""value""")
                    .Verifiable($"Verify call to {nameof(MockFragment.Object.CompileParameters)} on ${nameof(MockFragment)}");
        MockFragment.Setup(mock => mock.HasParameters)
                    .Returns(true)
                    .Verifiable($"Verify call to {nameof(MockFragment.Object.HasParameters)} on ${nameof(MockFragment)}");

        // Act
        string actual = ClassUnderTest.Compile();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockFragment.Verify();
    }

    [Test]
    public void CompileWhenVariablesAreSetOnRequestAndParametersAreNotSetFragmentReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"query ($key: String) { result: Request(key: $key) { field } }";
        ClassUnderTest.SetVariable("key", "String", "value")
                      .Fragment(MockFragment.Object);

        // Arrange - Stubbing
        MockFragment.Setup(mock => mock.CompileFields())
                    .Returns(@"field")
                    .Verifiable($"Verify call to {nameof(MockFragment.Object.CompileFields)} on ${nameof(MockFragment)}");
        MockFragment.Setup(mock => mock.HasParameters)
                    .Returns(false)
                    .Verifiable($"Verify call to {nameof(MockFragment.Object.HasParameters)} on ${nameof(MockFragment)}");

        // Act
        string actual = ClassUnderTest.Compile();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockFragment.Verify();
    }

    [Test]
    public void CompileWhenVariablesAreSetOnRequestAndParametersAreSetOnFragmentReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"query ($key1: String) { result: Request(key1: $key1, key2: ""value2"") { field } }";
        ClassUnderTest.SetVariable("key1", "String", "value1")
                      .Fragment(MockFragment.Object);

        // Arrange - Stubbing
        MockFragment.Setup(mock => mock.CompileFields())
                    .Returns(@"field")
                    .Verifiable($"Verify call to {nameof(MockFragment.Object.CompileFields)} on ${nameof(MockFragment)}");
        MockFragment.Setup(mock => mock.CompileParameters())
                    .Returns(@"key2: ""value2""")
                    .Verifiable($"Verify call to {nameof(MockFragment.Object.CompileParameters)} on ${nameof(MockFragment)}");
        MockFragment.Setup(mock => mock.HasParameters)
                    .Returns(true)
                    .Verifiable($"Verify call to {nameof(MockFragment.Object.HasParameters)} on ${nameof(MockFragment)}");

        // Act
        string actual = ClassUnderTest.Compile();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockFragment.Verify();
    }

    [Test]
    public void HasFragmentWhenFragmentIsNotSetReturnsFalse()
    {
        // Act
        bool actual = ClassUnderTest.HasFragment;

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void HasFragmentWhenFragmentIsSetReturnsTrue()
    {
        // Arrange
        ClassUnderTest.Fragment(MockFragment.Object);

        // Act
        bool actual = ClassUnderTest.HasFragment;

        // Assert
        Assert.That(actual, Is.True);
    }
}