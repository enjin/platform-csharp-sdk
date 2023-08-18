using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Enjin.Platform.Sdk.Marketplace;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class ListingStateJsonConverterTest
{
    private JsonSerializerOptions Options { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        Options = new JsonSerializerOptions
        {
            Converters = { new ListingStateJsonConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
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
        ListingState? actual = JsonSerializer.Deserialize<ListingState?>(json, Options);

        // Assert
        Assert.That(actual, Is.Null);
    }

    [Test]
    public void ReadWhenJsonDoesNotHaveTypeFieldReturnsNull()
    {
        // Arrange
        const string json = @"{}";

        // Act
        ListingState? actual = JsonSerializer.Deserialize<ListingState?>(json, Options);

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
        ListingState? actual = JsonSerializer.Deserialize<ListingState?>(json, Options);

        // Assert
        Assert.That(actual, Is.Null);
    }

    [Test]
    public void ReadWhenJsonRepresentsAuctionStateReturnsExpected()
    {
        // Arrange
        const ListingType expectedType = ListingType.Auction;
        const string json = @"{""type"":""AUCTION"",""highestBid"":{}}";

        // Act
        ListingState? actual = JsonSerializer.Deserialize<ListingState?>(json, Options);

        // Assert
        Assert.That(actual, Is.Not.Null.And.TypeOf<AuctionState>(),
                    $"Assert that {nameof(actual)} is of type {nameof(AuctionState)}");
        Assert.Multiple(() =>
        {
            AuctionState auctionState = (AuctionState)actual!;

            Assert.That(auctionState.Type, Is.Not.Null.And.EqualTo(expectedType),
                        $"Assert that {nameof(AuctionState.Type)} equals expected");
            Assert.That(auctionState.HighestBid, Is.Not.Null,
                        $"Assert that {nameof(AuctionState.HighestBid)} is not null");
        });
    }

    [Test]
    public void ReadWhenJsonRepresentsFixedPriceStateReturnsExpected()
    {
        // Arrange
        const ListingType expectedType = ListingType.FixedPrice;
        BigInteger expectedAmountFilled = 1;
        const string json = @"{""type"":""FIXED_PRICE"",""amountFilled"":""1""}";

        // Act
        ListingState? actual = JsonSerializer.Deserialize<ListingState?>(json, Options);

        // Assert
        Assert.That(actual, Is.Not.Null.And.TypeOf<FixedPriceState>(),
                    $"Assert that {nameof(actual)} is of type {nameof(FixedPriceState)}");
        Assert.Multiple(() =>
        {
            FixedPriceState fixedPriceData = (FixedPriceState)actual!;

            Assert.That(fixedPriceData.Type, Is.Not.Null.And.EqualTo(expectedType),
                        $"Assert that {nameof(FixedPriceState.Type)} equals expected");
            Assert.That(fixedPriceData.AmountFilled, Is.Not.Null.And.EqualTo(expectedAmountFilled),
                        $"Assert that {nameof(FixedPriceState.AmountFilled)} equals expected");
        });
    }

    [Test]
    public void WriteForNewListingDataTypeThrowsArgumentException()
    {
        // Arrange
        ListingState value = new DummyListingState();

        // Assert
        Assert.Throws<ArgumentException>(() => JsonSerializer.Serialize(value, Options));
    }

    [Test]
    public void WriteForAuctionDataReturnsExpected()
    {
        // Arrange
        const string expected = @"{""type"":""AUCTION"",""highestBid"":{}}";
        AuctionState? value = JsonSerializer.Deserialize<AuctionState?>(expected, Options);

        // Assumptions
        Assume.That(value, Is.Not.Null,
                    $"Assume that {nameof(value)} is not null");
        Assume.That(value!.Type, Is.Not.Null.And.EqualTo(ListingType.Auction),
                    $"Assume that {nameof(AuctionState.Type)} is set");
        Assume.That(value.HighestBid, Is.Not.Null,
                    $"Assume that {nameof(AuctionState.HighestBid)} is set");

        // Act
        string actual = JsonSerializer.Serialize(value, Options);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteForFixedPriceDataReturnsExpected()
    {
        // Arrange
        const string expected = @"{""type"":""FIXED_PRICE"",""amountFilled"":""1""}";
        FixedPriceState? value = JsonSerializer.Deserialize<FixedPriceState?>(expected, Options);

        // Assumptions
        Assume.That(value, Is.Not.Null,
                    $"Assume that {nameof(value)} is not null");
        Assume.That(value!.Type, Is.Not.Null.And.EqualTo(ListingType.FixedPrice),
                    $"Assume that {nameof(FixedPriceState.Type)} is set");
        Assume.That(value.AmountFilled, Is.Not.Null.And.EqualTo(new BigInteger(1)),
                    $"Assume that {nameof(FixedPriceState.AmountFilled)} is set");

        // Act
        string actual = JsonSerializer.Serialize(value, Options);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    private class DummyListingState : ListingState
    {
    }
}