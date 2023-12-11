using System.Numerics;
using System.Text.Json;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class BigIntegerJsonConverterTest
{
    private JsonSerializerOptions Options { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        Options = new JsonSerializerOptions
        {
            Converters = { new BigIntegerJsonConverter() }
        };
    }

    [Test]
    [TestCase(@"""0""")]
    [TestCase(@"""115792089237316195423570985008687907853269984665640564039457584007913129639935""")]
    [TestCase(@"""-115792089237316195423570985008687907853269984665640564039457584007913129639935""")]
    public void DeserializeWhenGivenValidJsonStringReturnsExpected(string json)
    {
        // Arrange
        string value = json.Replace("\"", "");
        BigInteger expected = BigInteger.Parse(value);

        // Act
        BigInteger actual = JsonSerializer.Deserialize<BigInteger>(json, Options);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(@"null")]
    [TestCase(@"""1.1579E+77""")]
    [TestCase(@"""1.0""")]
    [TestCase(@"[]")]
    [TestCase(@"{}")]
    [TestCase(@"""abc""")]
    public void DeserializeWhenGivenInvalidJsonValueThrowsFormatException(string json)
    {
        // Assert
        Assert.Throws<FormatException>(() => JsonSerializer.Deserialize<BigInteger>(json, Options));
    }
}