using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

public class ScalarGraphQlRequestImpl : GraphQlRequest<ScalarGraphQlRequestImpl>
{
    public ScalarGraphQlRequestImpl() : base("Request", GraphQlRequestType.Query)
    {
    }
}

[TestFixture]
public class ScalarGraphQlRequestTest
{
    private ScalarGraphQlRequestImpl ClassUnderTest { get; set; }

    [SetUp]
    public void BeforeEach()
    {
        ClassUnderTest = new ScalarGraphQlRequestImpl();
    }

    [Test]
    public void CompileWhenNoVariablesAreSetReturnsExpectedString()
    {
        // Arrange
        const string expected = @"query { result: Request }";

        // Assumptions
        Assume.That(ClassUnderTest.HasParameters, Is.False,
                    $"Assume {nameof(ClassUnderTest.HasParameters)} is false");

        // Act
        string actual = ClassUnderTest.Compile();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompileWhenVariablesAreSetReturnsExpectedString()
    {
        // Arrange
        const string expected = @"query ($key: String) { result: Request(key: $key) }";
        const string key = "key";
        const string value = "value";
        ClassUnderTest.SetVariable(key, "String", value);

        // Assumptions
        Assume.That(ClassUnderTest.HasVariables, Is.True,
                    $"Assume {nameof(ClassUnderTest.HasVariables)} is true");

        // Act
        string actual = ClassUnderTest.Compile();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}