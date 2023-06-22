using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of a <see cref="FixedPriceData"/> returned by the platform.
/// </summary>
[PublicAPI]
public class FixedPriceDataFragment : ListingDataFragment<FixedPriceDataFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FixedPriceDataFragment"/> class.
    /// </summary>
    public FixedPriceDataFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="FixedPriceData"/> is to be returned with its <see cref="FixedPriceData.Type"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FixedPriceDataFragment WithType(bool isIncluded = true)
    {
        return WithField("type", isIncluded);
    }
}