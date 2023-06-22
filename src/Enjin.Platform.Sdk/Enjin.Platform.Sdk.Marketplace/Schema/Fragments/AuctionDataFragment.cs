using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of a <see cref="AuctionData"/> returned by the platform.
/// </summary>
[PublicAPI]
public class AuctionDataFragment : ListingDataFragment<AuctionDataFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuctionDataFragment"/> class.
    /// </summary>
    public AuctionDataFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="AuctionData"/> is to be returned with its <see cref="AuctionData.Type"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AuctionDataFragment WithType(bool isIncluded = true)
    {
        return WithField("type", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="AuctionData"/> is to be returned with its <see cref="AuctionData.StartBlock"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AuctionDataFragment WithStartBlock(bool isIncluded = true)
    {
        return WithField("startBlock", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="AuctionData"/> is to be returned with its <see cref="AuctionData.EndBlock"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AuctionDataFragment WithEndBlock(bool isIncluded = true)
    {
        return WithField("endBlock", isIncluded);
    }
}