using System.Numerics;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class IntegerRangeTest
{
    [Test]
    [TestCase("0")]
    [TestCase("1000")]
    public void ConstructionWithValidValue(string valueStr)
    {
        // Arrange
        BigInteger value = BigInteger.Parse(valueStr);

        // Assert
        Assert.DoesNotThrow(() => new IntegerRange(value));
    }

    [Test]
    [TestCase("0", "0")]
    [TestCase("0", "1000")]
    public void ConstructionWithValidValueRange(string startStr, string endStr)
    {
        // Arrange
        BigInteger start = BigInteger.Parse(startStr);
        BigInteger end = BigInteger.Parse(endStr);

        // Assert
        Assert.DoesNotThrow(() => new IntegerRange(start, end));
    }

    [Test]
    [TestCase("1", "0")]
    public void ConstructionWithInvalidValueRange(string startStr, string endStr)
    {
        // Arrange
        BigInteger start = BigInteger.Parse(startStr);
        BigInteger end = BigInteger.Parse(endStr);

        // Assert
        Assert.Throws<ArgumentException>(() => new IntegerRange(start, end));
    }

    [Test]
    [TestCase("0", "0", "0")]
    [TestCase("0", "1000", "0..1000")]
    public void ToStringReturnsExpectedString(string startStr, string endStr, string expected)
    {
        // Arrange
        BigInteger start = BigInteger.Parse(startStr);
        BigInteger end = BigInteger.Parse(endStr);
        IntegerRange range = new IntegerRange(start, end);

        // Act
        string actual = range.ToString();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}