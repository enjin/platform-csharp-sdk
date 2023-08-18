using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of a <see cref="FixedPriceState"/> returned by the platform.
/// </summary>
[PublicAPI]
public class FixedPriceStateFragment : ListingStateFragment<FixedPriceStateFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FixedPriceStateFragment"/> class.
    /// </summary>
    public FixedPriceStateFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="FixedPriceState"/> is to be returned with its <see cref="FixedPriceState.Type"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    /// <remarks>
    /// This field ought to be requested when using this fragment type for a
    /// <see cref="ListingStateFragment{TFragment}"/> or else the <see cref="ListingStateJsonConverter"/> may not be
    /// able to determine the type.
    /// </remarks>
    public FixedPriceStateFragment WithType(bool isIncluded = true)
    {
        return WithField("type", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="FixedPriceState"/> is to be returned with its
    /// <see cref="FixedPriceState.AmountFilled"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FixedPriceStateFragment WithAmountFilled(bool isIncluded = true)
    {
        return WithField("amountFilled", isIncluded);
    }
}