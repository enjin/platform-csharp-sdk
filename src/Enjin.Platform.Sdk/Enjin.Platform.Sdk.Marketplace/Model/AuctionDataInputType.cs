using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models a parameter for data for an auction.
/// </summary>
[PublicAPI]
public class AuctionDataInputType : GraphQlParameter<AuctionDataInputType>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuctionDataInputType"/> class.
    /// </summary>
    public AuctionDataInputType()
    {
    }

    /// <summary>
    /// Sets the block number the auction starts at.
    /// </summary>
    /// <param name="startBlock">The block.</param>
    /// <returns>This parameter for chaining.</returns>
    public AuctionDataInputType SetStartBlock(int? startBlock)
    {
        return SetParameter("startBlock", startBlock);
    }

    /// <summary>
    /// Sets the block number the auction ends at.
    /// </summary>
    /// <param name="endBlock">The block.</param>
    /// <returns>This parameter for chaining.</returns>
    public AuctionDataInputType SetEndBlock(int? endBlock)
    {
        return SetParameter("endBlock", endBlock);
    }
}