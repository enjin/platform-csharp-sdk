using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of a <see cref="ListingData"/> returned by the platform.
/// </summary>
/// <typeparam name="TFragment">The type of the listing data fragment. Must extend this class.</typeparam>
[PublicAPI]
public abstract class ListingDataFragment<TFragment> : GraphQlFragment<TFragment>
    where TFragment : ListingDataFragment<TFragment>
{
}