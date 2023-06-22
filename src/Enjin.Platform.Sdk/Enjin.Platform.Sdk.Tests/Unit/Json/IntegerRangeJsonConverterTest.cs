using System.Text.Json;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class IntegerRangeJsonConverterTest
{
    private JsonSerializerOptions Options { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        Options = new JsonSerializerOptions
        {
            Converters = { new IntegerRangeJsonConverter() }
        };
    }

    [Test]
    [TestCase(@"""0""")]
    [TestCase(@"""1000..1001""")]
    [TestCase(@"null")]
    [TestCase(@"0")]
    [TestCase(@"1.0")]
    [TestCase(@"true")]
    [TestCase(@"[]")]
    [TestCase(@"{}")]
    public void DeserializeThrowsNotSupportedException(string json)
    {
        // Assert
        Assert.Throws<NotSupportedException>(() => JsonSerializer.Deserialize<IntegerRange>(json, Options));
    }

    [Test]
    [TestCase(0, 0, ExpectedResult = @"""0""")]
    [TestCase(0, 1, ExpectedResult = @"""0..1""")]
    [TestCase(1000, 1001, ExpectedResult = @"""1000..1001""")]
    [TestCase(1000, int.MaxValue, ExpectedResult = @"""1000..2147483647""")]
    public string SerializeWhenUsingStartEndConstructorReturnsExpectedResult(int start, int end)
    {
        // Arrange
        IntegerRange range = new IntegerRange(start, end);

        // Act
        return JsonSerializer.Serialize(range, Options);
    }

    [Test]
    [TestCase(0, ExpectedResult = @"""0""")]
    [TestCase(1, ExpectedResult = @"""1""")]
    [TestCase(1000, ExpectedResult = @"""1000""")]
    [TestCase(int.MaxValue, ExpectedResult = @"""2147483647""")]
    public string SerializeWhenUsingSingleValueConstructorReturnsExpectedResult(int value)
    {
        // Arrange
        IntegerRange range = new IntegerRange(value);

        // Act
        return JsonSerializer.Serialize(range, Options);
    }
}