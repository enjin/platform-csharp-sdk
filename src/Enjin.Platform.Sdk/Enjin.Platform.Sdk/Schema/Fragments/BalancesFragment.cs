using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of <see cref="Balances"/> returned by the platform.
/// </summary>
[PublicAPI]
public class BalancesFragment : GraphQlFragment<BalancesFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Balances"/> class.
    /// </summary>
    public BalancesFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Balances"/> is to be returned with its <see cref="Balances.Free"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BalancesFragment WithFree(bool isIncluded = true)
    {
        return WithField("free", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Balances"/> is to be returned with its <see cref="Balances.Reserved"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BalancesFragment WithReserved(bool isIncluded = true)
    {
        return WithField("reserved", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Balances"/> is to be returned with its <see cref="Balances.MiscFrozen"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BalancesFragment WithMiscFrozen(bool isIncluded = true)
    {
        return WithField("miscFrozen", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Balances"/> is to be returned with its <see cref="Balances.FeeFrozen"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BalancesFragment WithFeeFrozen(bool isIncluded = true)
    {
        return WithField("feeFrozen", isIncluded);
    }
}