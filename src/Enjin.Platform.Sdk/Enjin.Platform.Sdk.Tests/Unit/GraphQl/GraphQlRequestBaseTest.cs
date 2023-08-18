using System.Text;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

public class GraphQlRequestBaseImpl : GraphQlRequestBase<GraphQlRequestBaseImpl>
{
    public GraphQlRequestBaseImpl(string name, GraphQlRequestType type) : base(name, type)
    {
    }

    public new void AppendHeader(StringBuilder builder) => base.AppendHeader(builder);

    public override string Compile() => string.Empty;
}

[TestFixture]
public class GraphQlRequestBaseTest
{
    [Test]
    public void AppendHeaderWhenRequestHasNoVariablesOrParametersAppendsExpectedStringsToBuilder()
    {
        // Arrange
        const string expected = "query { result: Request";
        StringBuilder builder = new();
        GraphQlRequestBaseImpl request = new GraphQlRequestBaseImpl("Request", GraphQlRequestType.Query);

        // Act
        request.AppendHeader(builder);

        // Assert
        Assert.That(builder.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void AppendHeaderWhenRequestHasVariablesAndNoParametersAppendsExpectedStringsToBuilder()
    {
        // Arrange
        const string expected = "query ($var: Int) { result: Request(var: $var)";
        StringBuilder builder = new();
        GraphQlRequestBaseImpl request = new GraphQlRequestBaseImpl("Request", GraphQlRequestType.Query);
        request.SetVariable("var", "Int", 1);

        // Act
        request.AppendHeader(builder);

        // Assert
        Assert.That(builder.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void AppendHeaderWhenRequestHasParametersAndNoVariablesAppendsExpectedStringsToBuilder()
    {
        // Arrange
        const string expected = "query { result: Request(param: 1)";
        StringBuilder builder = new();
        GraphQlRequestBaseImpl request = new GraphQlRequestBaseImpl("Request", GraphQlRequestType.Query);
        request.SetParameter("param", 1);

        // Act
        request.AppendHeader(builder);

        // Assert
        Assert.That(builder.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void AppendHeaderWhenRequestHasVariablesAndParametersAppendsExpectedStringsToBuilder()
    {
        // Arrange
        const string expected = "query ($var: Int) { result: Request(var: $var, param: 1)";
        StringBuilder builder = new();
        GraphQlRequestBaseImpl request = new GraphQlRequestBaseImpl("Request", GraphQlRequestType.Query);
        request.SetVariable("var", "Int", 1);
        request.SetParameter("param", 1);

        // Act
        request.AppendHeader(builder);

        // Assert
        Assert.That(builder.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void HasVariableWhenRequestDoesNotHaveVariableReturnsFalse()
    {
        // Arrange
        const string name = "var";
        GraphQlRequestBaseImpl request = new GraphQlRequestBaseImpl("Request", GraphQlRequestType.Query);

        // Act
        bool actual = request.HasVariable(name);

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void HasVariableWhenRequestHasVariableReturnsTrue()
    {
        // Arrange
        const string name = "var";
        GraphQlRequestBaseImpl request = new GraphQlRequestBaseImpl("Request", GraphQlRequestType.Query);
        request.SetVariable(name, "Int", 1);

        // Act
        bool actual = request.HasVariable(name);

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void HasVariablesWhenNoVariableHasBeenSetReturnsFalse()
    {
        // Arrange
        GraphQlRequestBaseImpl request = new GraphQlRequestBaseImpl("Request", GraphQlRequestType.Query);

        // Act
        bool actual = request.HasVariables;

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void HasVariablesWhenVariablesHaveBeenSetReturnsTrue()
    {
        // Arrange
        GraphQlRequestBaseImpl request = new GraphQlRequestBaseImpl("Request", GraphQlRequestType.Query);
        request.SetVariable("id", "Int", 0);

        // Act
        bool actual = request.HasVariables;

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void SetVariableVariablePropertiesHaveExpectedEntries()
    {
        // Arrange
        const string expectedName = "id";
        const string expectedType = "Int";
        const int expectedValue = 1;
        GraphQlRequestBaseImpl request = new GraphQlRequestBaseImpl("Request", GraphQlRequestType.Query);

        // Act
        request.SetVariable(expectedName, expectedType, expectedValue);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(request.Variables, Does.ContainKey(expectedName),
                        $"Assert {nameof(request.Variables)} contains expected key");
            Assert.That(request.Variables, Does.ContainValue(new Tuple<string, object?>(expectedType, expectedValue)),
                        $"Assert {nameof(request.Variables)} contains expected value");
            Assert.That(request.VariablesWithoutTypes, Does.ContainKey(expectedName),
                        $"Assert {nameof(request.VariablesWithoutTypes)} contains expected key");
            Assert.That(request.VariablesWithoutTypes, Does.ContainValue(expectedValue),
                        $"Assert {nameof(request.VariablesWithoutTypes)} contains expected value");
        });
    }
}