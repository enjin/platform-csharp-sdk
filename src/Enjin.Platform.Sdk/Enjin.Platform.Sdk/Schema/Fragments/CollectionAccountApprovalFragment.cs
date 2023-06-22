using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="CollectionAccountApproval"/> returned by the platform.
/// </summary>
[PublicAPI]
public class CollectionAccountApprovalFragment : GraphQlFragment<CollectionAccountApprovalFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionAccountApprovalFragment"/> class.
    /// </summary>
    public CollectionAccountApprovalFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="CollectionAccountApproval"/> is to be returned with its
    /// <see cref="CollectionAccountApproval.Expiration"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionAccountApprovalFragment WithExpiration(bool isIncluded = true)
    {
        return WithField("expiration", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="CollectionAccount"/> fragment to be used for getting the
    /// <see cref="CollectionAccountApproval.Account"/> property of the <see cref="CollectionAccountApproval"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="CollectionAccount"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionAccountApprovalFragment WithAccount(CollectionAccountFragment? fragment)
    {
        return WithField("account", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="CollectionAccountApproval.Wallet"/>
    /// property of the <see cref="CollectionAccountApproval"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionAccountApprovalFragment WithWallet(WalletFragment? fragment)
    {
        return WithField("wallet", fragment);
    }
}