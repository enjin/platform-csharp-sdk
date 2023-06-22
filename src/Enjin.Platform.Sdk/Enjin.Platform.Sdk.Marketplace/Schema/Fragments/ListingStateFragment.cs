using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of a <see cref="ListingState"/> returned by the platform.
/// </summary>
/// <typeparam name="TFragment">The type of the listing state fragment. Must extend this class.</typeparam>
[PublicAPI]
public abstract class ListingStateFragment<TFragment> : GraphQlFragment<TFragment>
    where TFragment : ListingStateFragment<TFragment>
{
}