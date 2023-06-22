using System.Text.Json;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class UploadJsonConverterTest
{
    private JsonSerializerOptions Options { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        Options = new JsonSerializerOptions
        {
            Converters = { new UploadJsonConverter() }
        };
    }

    [Test]
    [TestCase(@"null")]
    [TestCase(@"true")]
    [TestCase(@"false")]
    [TestCase(@"0")]
    [TestCase(@"0.0")]
    [TestCase(@"[]")]
    [TestCase(@"{}")]
    [TestCase(@"""abc""")]
    public void DeserializeThrowsNotSupportedException(string json)
    {
        // Assert
        Assert.Throws<NotSupportedException>(() => JsonSerializer.Deserialize<Upload>(json, Options));
    }

    [Test]
    public void SerializeGivenUploadReturnsNullJson()
    {
        // Arrange
        const string expected = "null";
        Upload upload = new Upload(File.OpenRead("Test Data/a.txt"));

        // Act
        string actual = JsonSerializer.Serialize(upload, Options);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}