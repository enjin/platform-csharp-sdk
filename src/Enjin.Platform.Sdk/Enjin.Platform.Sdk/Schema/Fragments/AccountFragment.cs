using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of an <see cref="Account"/> returned by the platform.
/// </summary>
[PublicAPI]
public class AccountFragment : GraphQlFragment<AccountFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountFragment"/> class.
    /// </summary>
    public AccountFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Account"/> is to be returned with its <see cref="Account.PublicKey"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AccountFragment WithPublicKey(bool isIncluded = true)
    {
        return WithField("publicKey", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Account"/> is to be returned with its <see cref="Account.Address"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AccountFragment WithAddress(bool isIncluded = true)
    {
        return WithField("address", isIncluded);
    }
}