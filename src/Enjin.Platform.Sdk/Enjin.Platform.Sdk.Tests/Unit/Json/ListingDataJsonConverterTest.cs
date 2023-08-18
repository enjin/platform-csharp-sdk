using System.Text.Json;
using Enjin.Platform.Sdk.Marketplace;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class ListingDataJsonConverterTest
{
    private JsonSerializerOptions Options { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        Options = new JsonSerializerOptions
        {
            Converters = { new ListingDataJsonConverter() }
        };
    }

    [Test]
    [TestCase(@"null")]
    [TestCase(@"true")]
    [TestCase(@"false")]
    [TestCase(@"1")]
    [TestCase(@"""""")]
    [TestCase(@"[]")]
    public void ReadWhenJsonIsNotAnObjectReturnsNull(string json)
    {
        // Act
        ListingData? actual = JsonSerializer.Deserialize<ListingData?>(json, Options);

        // Assert
        Assert.That(actual, Is.Null);
    }

    [Test]
    public void ReadWhenJsonDoesNotHaveTypeFieldReturnsNull()
    {
        // Arrange
        const string json = @"{}";

        // Act
        ListingData? actual = JsonSerializer.Deserialize<ListingData?>(json, Options);

        // Assert
        Assert.That(actual, Is.Null);
    }

    [Test]
    [TestCase(@"{""type"":null}")]
    [TestCase(@"{""type"":true}")]
    [TestCase(@"{""type"":false}")]
    [TestCase(@"{""type"":1}")]
    [TestCase(@"{""type"":[]}")]
    [TestCase(@"{""type"":{}}")]
    public void ReadWhenJsonHasNonStringTypeFieldReturnsNull(string json)
    {
        // Act
        ListingData? actual = JsonSerializer.Deserialize<ListingData?>(json, Options);

        // Assert
        Assert.That(actual, Is.Null);
    }

    [Test]
    public void ReadWhenJsonRepresentsAuctionDataReturnsExpected()
    {
        // Arrange
        const ListingType expectedType = ListingType.Auction;
        const int expectedStartBlock = 1;
        const int expectedEndBlock = 1;
        const string json = @"{""type"":""AUCTION"",""startBlock"":1,""endBlock"":1}";

        // Act
        ListingData? actual = JsonSerializer.Deserialize<ListingData?>(json, Options);

        // Assert
        Assert.That(actual, Is.Not.Null.And.TypeOf<AuctionData>(),
                    $"Assert that {nameof(actual)} is of type {nameof(AuctionData)}");
        Assert.Multiple(() =>
        {
            AuctionData auctionData = (AuctionData)actual!;

            Assert.That(auctionData.Type, Is.Not.Null.And.EqualTo(expectedType),
                        $"Assert that {nameof(AuctionData.Type)} equals expected");
            Assert.That(auctionData.StartBlock, Is.Not.Null.And.EqualTo(expectedStartBlock),
                        $"Assert that {nameof(AuctionData.StartBlock)} equals expected");
            Assert.That(auctionData.EndBlock, Is.Not.Null.And.EqualTo(expectedEndBlock),
                        $"Assert that {nameof(AuctionData.EndBlock)} equals expected");
        });
    }

    [Test]
    public void ReadWhenJsonRepresentsFixedPriceDataReturnsExpected()
    {
        // Arrange
        const ListingType expectedType = ListingType.FixedPrice;
        const string json = @"{""type"":""FIXED_PRICE""}";

        // Act
        ListingData? actual = JsonSerializer.Deserialize<ListingData?>(json, Options);

        // Assert
        Assert.That(actual, Is.Not.Null.And.TypeOf<FixedPriceData>(),
                    $"Assert that {nameof(actual)} is of type {nameof(FixedPriceData)}");
        Assert.Multiple(() =>
        {
            FixedPriceData fixedPriceData = (FixedPriceData)actual!;

            Assert.That(fixedPriceData.Type, Is.Not.Null.And.EqualTo(expectedType),
                        $"Assert that {nameof(FixedPriceData.Type)} equals expected");
        });
    }

    [Test]
    public void WriteForNewListingDataTypeThrowsArgumentException()
    {
        // Arrange
        ListingData value = new DummyListingData();

        // Assert
        Assert.Throws<ArgumentException>(() => JsonSerializer.Serialize(value, Options));
    }

    [Test]
    public void WriteForAuctionDataReturnsExpected()
    {
        // Arrange
        const string expected = @"{""type"":""AUCTION"",""startBlock"":1,""endBlock"":1}";
        AuctionData? value = JsonSerializer.Deserialize<AuctionData?>(expected, Options);

        // Assumptions
        Assume.That(value, Is.Not.Null,
                    $"Assume that {nameof(value)} is not null");
        Assume.That(value!.Type, Is.Not.Null.And.EqualTo(ListingType.Auction),
                    $"Assume that {nameof(AuctionData.Type)} is set");
        Assume.That(value.StartBlock, Is.Not.Null.And.EqualTo(1),
                    $"Assume that {nameof(AuctionData.StartBlock)} is set");
        Assume.That(value.EndBlock, Is.Not.Null.And.EqualTo(1),
                    $"Assume that {nameof(AuctionData.EndBlock)} is set");

        // Act
        string actual = JsonSerializer.Serialize(value, Options);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteForFixedPriceDataReturnsExpected()
    {
        // Arrange
        const string expected = @"{""type"":""FIXED_PRICE""}";
        FixedPriceData? value = JsonSerializer.Deserialize<FixedPriceData?>(expected, Options);

        // Assumptions
        Assume.That(value, Is.Not.Null,
                    $"Assume that {nameof(value)} is not null");
        Assume.That(value!.Type, Is.Not.Null.And.EqualTo(ListingType.FixedPrice),
                    $"Assume that {nameof(FixedPriceData.Type)} is set");

        // Act
        string actual = JsonSerializer.Serialize(value, Options);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    private class DummyListingData : ListingData
    {
    }
}