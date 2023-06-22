using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of a <see cref="Asset"/> returned by the platform.
/// </summary>
[PublicAPI]
public class AssetFragment : GraphQlFragment<AssetFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AssetFragment"/> class.
    /// </summary>
    public AssetFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Asset"/> is to be returned with its <see cref="Asset.CollectionId"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AssetFragment WithCollectionId(bool isIncluded = true)
    {
        return WithField("collectionId", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Asset"/> is to be returned with its <see cref="Asset.TokenId"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AssetFragment WithTokenId(bool isIncluded = true)
    {
        return WithField("tokenId", isIncluded);
    }
}