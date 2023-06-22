using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="TokenAccountNamedReserve"/> returned by the platform.
/// </summary>
[PublicAPI]
public class TokenAccountNamedReserveFragment : GraphQlFragment<TokenAccountNamedReserveFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenAccountNamedReserveFragment"/> class.
    /// </summary>
    public TokenAccountNamedReserveFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="TokenAccountNamedReserve"/> is to be returned with its
    /// <see cref="TokenAccountNamedReserve.Pallet"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountNamedReserveFragment WithPallet(bool isIncluded = true)
    {
        return WithField("pallet", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="TokenAccountNamedReserve"/> is to be returned with its
    /// <see cref="TokenAccountNamedReserve.Amount"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountNamedReserveFragment WithAmount(bool isIncluded = true)
    {
        return WithField("amount", isIncluded);
    }
}