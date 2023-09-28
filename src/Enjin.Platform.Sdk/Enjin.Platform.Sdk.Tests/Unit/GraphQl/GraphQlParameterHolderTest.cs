using System.Numerics;
using Moq;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

public class GraphQlParameterHolderImpl : GraphQlParameterHolder<GraphQlParameterHolderImpl>
{
}

[TestFixture]
public class GraphQlParameterHolderTest
{
    private GraphQlParameterHolderImpl ClassUnderTest { get; set; }

    // Mocks
    private Mock<IGraphQlParameter> MockParameter { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        MockParameter = new Mock<IGraphQlParameter>();
    }

    [SetUp]
    public void BeforeEach()
    {
        MockParameter.Reset();

        ClassUnderTest = new GraphQlParameterHolderImpl();
    }

    [Test]
    public void CompileParametersWhenHoldingNoParameterReturnsEmptyString()
    {
        // Arrange
        string expected = string.Empty;

        // Act
        string actual = ClassUnderTest.CompileParameters();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompileParametersWhenHoldingBigIntegerParameterReturnsExpectedString()
    {
        // Arrange
        const string expected = @"key: ""1000""";
        const string key = "key";
        BigInteger value = 1000;
        ClassUnderTest.SetParameter(key, value);

        // Act
        string actual = ClassUnderTest.CompileParameters();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompileParametersWhenHoldingIntegerParameterReturnsExpectedString()
    {
        // Arrange
        const string expected = @"key: 1000";
        const string key = "key";
        const int value = 1000;
        ClassUnderTest.SetParameter(key, value);

        // Act
        string actual = ClassUnderTest.CompileParameters();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompileParametersWhenHoldingStringParameterReturnsExpectedString()
    {
        // Arrange
        const string expected = @"key: ""value""";
        const string key = "key";
        const string value = "value";
        ClassUnderTest.SetParameter(key, value);

        // Act
        string actual = ClassUnderTest.CompileParameters();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompileParametersWhenHoldingComplexParameterReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"key: { parameter }";
        const string key = "key";
        ClassUnderTest.SetParameter(key, MockParameter.Object);

        // Arrange - Stubbing
        MockParameter.Setup(mock => mock.Compile())
                     .Returns(@"{ parameter }")
                     .Verifiable($"Verify call to {nameof(MockParameter.Object.Compile)} on ${nameof(MockParameter)}");

        // Act
        string actual = ClassUnderTest.CompileParameters();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockParameter.Verify();
    }

    [Test]
    public void CompileParametersWhenHoldingSingleListedComplexParameterReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"key: [ { parameter } ]";
        const string key = "key";
        IGraphQlParameter[] values = { MockParameter.Object };
        ClassUnderTest.SetParameter(key, values);

        // Arrange - Stubbing
        MockParameter.Setup(mock => mock.Compile())
                     .Returns(@"{ parameter }")
                     .Verifiable($"Verify call to {nameof(MockParameter.Object.Compile)} on ${nameof(MockParameter)}");

        // Act
        string actual = ClassUnderTest.CompileParameters();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockParameter.Verify();
    }

    [Test]
    public void CompileParametersWhenHoldingMultipleListedComplexParametersReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"key: [ { parameter }, { parameter }, { parameter } ]";
        const string key = "key";
        IGraphQlParameter value = MockParameter.Object;
        ClassUnderTest.SetParameter(key, value, value, value);

        // Arrange - Stubbing
        MockParameter.Setup(mock => mock.Compile())
                     .Returns(@"{ parameter }")
                     .Verifiable($"Verify call to {nameof(MockParameter.Object.Compile)} on ${nameof(MockParameter)}");

        // Act
        string actual = ClassUnderTest.CompileParameters();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockParameter.Verify();
    }

    [Test]
    public void CompileParametersWhenHoldingMultipleParametersReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"key1: ""value1"", key2: { parameter }, key3: [ { parameter } ]";
        const string key1 = "key1";
        const string key2 = "key2";
        const string key3 = "key3";
        const string value1 = "value1";
        IGraphQlParameter value2 = MockParameter.Object;
        IGraphQlParameter[] value3 = { MockParameter.Object };
        ClassUnderTest.SetParameter(key1, value1);
        ClassUnderTest.SetParameter(key2, value2);
        ClassUnderTest.SetParameter(key3, value3);

        // Arrange - Stubbing
        MockParameter.Setup(mock => mock.Compile())
                     .Returns(@"{ parameter }")
                     .Verifiable($"Verify call to {nameof(MockParameter.Object.Compile)} on ${nameof(MockParameter)}");

        // Act
        string actual = ClassUnderTest.CompileParameters();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockParameter.Verify();
    }

    [Test]
    public void HasParameterWhenHolderDoesNotHaveParameterReturnsFalse()
    {
        // Arrange
        const string key = "key";

        // Act
        bool actual = ClassUnderTest.HasParameter(key);

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void HasParameterWhenHolderHasParameterReturnsTrue()
    {
        // Arrange
        const string key = "key";
        IGraphQlParameter value = MockParameter.Object;
        ClassUnderTest.SetParameter(key, value);

        // Act
        bool actual = ClassUnderTest.HasParameter(key);

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void HasParametersWhenNoParametersAreSetReturnsFalse()
    {
        // Act
        bool actual = ClassUnderTest.HasParameters;

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void HasParametersWhenParameterIsSetReturnsTrue()
    {
        // Arrange
        const string key = "key";
        const string value = "value";
        ClassUnderTest.SetParameter(key, value);

        // Act
        bool actual = ClassUnderTest.HasParameters;

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void SetParameterWhenGivenNonNullValueAddsParameter()
    {
        // Arrange
        const string key = "key";
        IGraphQlParameter value = MockParameter.Object;

        // Assumptions
        Assume.That(ClassUnderTest.Parameters, Does.Not.ContainKey(key));

        // Act
        ClassUnderTest.SetParameter(key, value);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(ClassUnderTest.Parameters, Does.ContainKey(key),
                        $"Assert {nameof(ClassUnderTest.Parameters)} contains expected key");
            Assert.That(ClassUnderTest.Parameters, Does.ContainValue(value),
                        $"Assert {nameof(ClassUnderTest.Parameters)} contains expected value");
        });
    }

    [Test]
    public void SetParameterWhenGivenNullValueRemovesParameter()
    {
        // Arrange
        const string key = "key";
        IGraphQlParameter? value = null;
        ClassUnderTest.SetParameter(key, "value");

        // Assumptions
        Assume.That(ClassUnderTest.Parameters, Does.ContainKey(key));

        // Act
        ClassUnderTest.SetParameter(key, value);

        // Assert
        Assert.That(ClassUnderTest.Parameters, Does.Not.ContainKey(key));
    }

    [Test]
    public void SetParameterWhenGivenNullListRemovesParameter()
    {
        // Arrange
        const string key = "key";
        IGraphQlParameter[]? value = null;
        ClassUnderTest.SetParameter(key, "value");

        // Assumptions
        Assume.That(ClassUnderTest.Parameters, Does.ContainKey(key));

        // Act
        ClassUnderTest.SetParameter(key, value);

        // Assert
        Assert.That(ClassUnderTest.Parameters, Does.Not.ContainKey(key));
    }
}