using System.Numerics;
using System.Text.Json;
using Moq;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class GraphQlParameterJsonConverterTest
{
    private JsonSerializerOptions Options { get; set; }

    // Mocks
    private Mock<IGraphQlParameter> MockParameter { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        MockParameter = new Mock<IGraphQlParameter>();

        Options = new JsonSerializerOptions
        {
            Converters = { new GraphQlParameterJsonConverter<IGraphQlParameter>() }
        };
    }

    [SetUp]
    public void BeforeEach()
    {
        MockParameter.Reset();
    }

    [Test]
    public void SerializeGivenGraphQlParameterReturnsExpectedJson()
    {
        // Arrange - Data
        const string expected = @"{""key"":""value""}";
        Dictionary<string, object?> parameters = new()
        {
            { "key", "value" },
        };

        // Arrange - Stubbing
        MockParameter.Setup(mock => mock.Parameters)
                     .Returns(parameters)
                     .Verifiable($"Verify call to {nameof(MockParameter.Object.Parameters)} on ${nameof(MockParameter)}");

        // Act
        string actual = JsonSerializer.Serialize(MockParameter.Object, Options);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockParameter.Verify();
    }
    
    [Test]
    public void SerializeGivenListGraphQlParameterReturnsExpectedJson()
    {
        // Arrange - Data
        const string expected = @"{""key"":[{""param1"":1},{""param2"":true}]}";
        var parameter1 = new TestGraphQlParameter();
        parameter1.Set("param1", new BigInteger(1));
        var parameter2 = new TestGraphQlParameter();
        parameter2.Set("param2", true);
        Dictionary<string, object?> parameters = new()
        {
            { "key", new List<IGraphQlParameter> {parameter1, parameter2} },
        };

        // Arrange - Stubbing
        MockParameter.Setup(mock => mock.Parameters)
                     .Returns(parameters)
                     .Verifiable($"Verify call to {nameof(MockParameter.Object.Parameters)} on ${nameof(MockParameter)}");

        // Act
        string actual = JsonSerializer.Serialize(MockParameter.Object, Options);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockParameter.Verify();
    }
}