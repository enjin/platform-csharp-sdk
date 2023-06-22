using Moq;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

public class GraphQlParameterImpl : GraphQlParameter<GraphQlParameterImpl>
{
}

[TestFixture]
public class GraphQlParameterTest
{
    private GraphQlParameterImpl ClassUnderTest { get; set; }

    private Mock<IGraphQlParameter> MockInnerParameter { get; set; }

    [SetUp]
    public void SetUp()
    {
        ClassUnderTest = new GraphQlParameterImpl();
        MockInnerParameter = new Mock<IGraphQlParameter>();
    }

    [Test]
    public void CompileWhenHoldNoParametersReturnsExpectedString()
    {
        // Arrange
        const string expected = @"{ }";

        // Assumptions
        Assume.That(ClassUnderTest.HasParameters, Is.False);

        // Act
        string actual = ClassUnderTest.Compile();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompileWhenHoldParametersReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"{ key1: ""value1"", key2: { innerParameter }, key3: [ { innerParameter } ] }";
        const string key1 = "key1";
        const string key2 = "key2";
        const string key3 = "key3";
        const string value1 = "value1";
        IGraphQlParameter value2 = MockInnerParameter.Object;
        IGraphQlParameter[] value3 = { MockInnerParameter.Object };
        ClassUnderTest.SetParameter(key1, value1);
        ClassUnderTest.SetParameter(key2, value2);
        ClassUnderTest.SetParameter(key3, value3);

        // Arrange - Stubbing
        MockInnerParameter.Setup(mock => mock.Compile())
                          .Returns(@"{ innerParameter }");

        // Assumptions
        Assume.That(ClassUnderTest.HasParameters, Is.True);

        // Act
        string actual = ClassUnderTest.Compile();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockInnerParameter.Verify(mock => mock.Compile(), Times.Exactly(2));
    }

    [Test]
    public void SetParameterWhenParameterIsOwnInstanceThrowsArgumentException()
    {
        // Arrange
        const string key = "key";
        IGraphQlParameter parameter = ClassUnderTest;

        // Assert
        Assert.Throws<ArgumentException>(() => ClassUnderTest.SetParameter(key, parameter));
    }

    [Test]
    public void SetParameterWhenParametersContainsOwnInstanceThrowsArgumentException()
    {
        // Arrange
        const string key = "key";
        IGraphQlParameter[] parameters = { ClassUnderTest };

        // Assert
        Assert.Throws<ArgumentException>(() => ClassUnderTest.SetParameter(key, parameters));
    }
}