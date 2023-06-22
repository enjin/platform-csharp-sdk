using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models a parameter for an asset.
/// </summary>
[PublicAPI]
public class AssetInputType : GraphQlParameter<AssetInputType>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AssetInputType"/> class.
    /// </summary>
    public AssetInputType()
    {
    }

    /// <summary>
    /// Sets the collection ID of the asset.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This parameter for chaining.</returns>
    public AssetInputType SetCollectionId(BigInteger? collectionId)
    {
        return SetParameter("collectionId", collectionId);
    }

    /// <summary>
    /// Sets the token ID of the asset.
    /// </summary>
    /// <param name="tokenId">The token ID.</param>
    /// <returns>This parameter for chaining.</returns>
    public AssetInputType SetTokenId(BigInteger? tokenId)
    {
        return SetParameter("tokenId", tokenId);
    }
}