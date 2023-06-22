using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of an <see cref="AccountVerified"/> returned by the platform.
/// </summary>
[PublicAPI]
public class AccountVerifiedFragment : GraphQlFragment<AccountVerifiedFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountVerifiedFragment"/> class.
    /// </summary>
    public AccountVerifiedFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="AccountVerified"/> is to be returned with its <see cref="AccountVerified.Verified"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AccountVerifiedFragment WithVerified(bool isIncluded = true)
    {
        return WithField("verified", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Account"/> fragment to be used for getting the <see cref="AccountVerified.Account"/>
    /// property of the <see cref="AccountVerified"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Account"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public AccountVerifiedFragment WithAccount(AccountFragment? fragment)
    {
        return WithField("account", fragment);
    }
}