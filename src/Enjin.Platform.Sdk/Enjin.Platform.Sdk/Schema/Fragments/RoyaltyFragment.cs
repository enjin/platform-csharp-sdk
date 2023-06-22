using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="Royalty"/> returned by the platform.
/// </summary>
[PublicAPI]
public class RoyaltyFragment : GraphQlFragment<RoyaltyFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoyaltyFragment"/> class.
    /// </summary>
    public RoyaltyFragment()
    {
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Royalty.Beneficiary"/> property of
    /// the <see cref="Royalty"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public RoyaltyFragment WithBeneficiary(WalletFragment? fragment)
    {
        return WithField("beneficiary", fragment);
    }

    /// <summary>
    /// Sets whether the <see cref="Royalty"/> is to be returned with its <see cref="Royalty.Percentage"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public RoyaltyFragment WithPercentage(bool isIncluded = true)
    {
        return WithField("percentage", isIncluded);
    }
}