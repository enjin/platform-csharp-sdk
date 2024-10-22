using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models a parameter for an asset.
/// </summary>
[PublicAPI]
public class AuctionParamsInput : GraphQlParameter<AuctionParamsInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuctionParamsInput"/> class.
    /// </summary>
    public AuctionParamsInput()
    {
    }

    /// <summary>
    /// Sets the start block number.
    /// </summary>
    /// <param name="startBlock">The start block number.</param>
    /// <returns>This parameter for chaining.</returns>
    public AuctionParamsInput SetStartBlock(int? startBlock)
    {
        return SetParameter("startBlock", startBlock);
    }

    /// <summary>
    /// Sets the end block number.
    /// </summary>
    /// <param name="endBlock">The end block number.</param>
    /// <returns>This parameter for chaining.</returns>
    public AuctionParamsInput SetEndBlock(int? endBlock)
    {
        return SetParameter("endBlock", endBlock);
    }
}