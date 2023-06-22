using System.Globalization;
using System.Text.Json;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class NullableDateTimeJsonConverterTest
{
    private JsonSerializerOptions Options { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        Options = new JsonSerializerOptions
        {
            Converters = { new NullableDateTimeJsonConverter() }
        };
    }

    [Test]
    [TestCase(@"""2000-01-01T00:00:00+00:00""")]
    public void DeserializeWhenGivenValidJsonStringReturnsExpected(string json)
    {
        // Arrange
        string value = json.Replace("\"", "");
        DateTime expected = DateTime.Parse(value, CultureInfo.InvariantCulture);

        // Act
        DateTime? actual = JsonSerializer.Deserialize<DateTime?>(json, Options);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Not.Null, "Assert actual is not null");
            Assert.That(actual, Is.EqualTo(expected), "Assert actual equals expected");
        });
    }

    [Test]
    public void DeserializeWhenGivenNullJsonStringReturnsNull()
    {
        // Arrange
        const string json = "null";

        // Act
        DateTime? actual = JsonSerializer.Deserialize<DateTime?>(json, Options);

        // Assert
        Assert.That(actual, Is.Null);
    }

    [Test]
    [TestCase(@"0")]
    [TestCase(@"""2000""")]
    [TestCase(@"[]")]
    [TestCase(@"{}")]
    [TestCase(@"""abc""")]
    public void DeserializeWhenGivenInvalidJsonValueThrowsFormatException(string json)
    {
        // Assert
        Assert.Throws<FormatException>(() => JsonSerializer.Deserialize<DateTime?>(json, Options));
    }
}