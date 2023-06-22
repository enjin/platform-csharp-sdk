using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="TokenAccountApproval"/> returned by the platform.
/// </summary>
[PublicAPI]
public class TokenAccountApprovalFragment : GraphQlFragment<TokenAccountApprovalFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenAccountApprovalFragment"/> class.
    /// </summary>
    public TokenAccountApprovalFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="TokenAccountApproval"/> is to be returned with its
    /// <see cref="TokenAccountApproval.Amount"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountApprovalFragment WithAmount(bool isIncluded = true)
    {
        return WithField("amount", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="TokenAccountApproval"/> is to be returned with its
    /// <see cref="TokenAccountApproval.Expiration"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountApprovalFragment WithExpiration(bool isIncluded = true)
    {
        return WithField("expiration", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="TokenAccount"/> fragment to be used for getting the
    /// <see cref="TokenAccountApproval.Account"/> property of the <see cref="TokenAccountApproval"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="TokenAccount"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountApprovalFragment WithAccount(TokenAccountFragment? fragment)
    {
        return WithField("account", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="TokenAccountApproval.Wallet"/>
    /// property of the <see cref="TokenAccountApproval"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountApprovalFragment WithWallet(WalletFragment? fragment)
    {
        return WithField("wallet", fragment);
    }
}