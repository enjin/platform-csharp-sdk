using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="CollectionAccount"/> returned by the platform.
/// </summary>
[PublicAPI]
public class CollectionAccountFragment : GraphQlFragment<CollectionAccountFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionAccountFragment"/> class.
    /// </summary>
    public CollectionAccountFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="CollectionAccount"/> is to be returned with its
    /// <see cref="CollectionAccount.AccountCount"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionAccountFragment WithAccountCount(bool isIncluded = true)
    {
        return WithField("accountCount", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="CollectionAccount"/> is to be returned with its
    /// <see cref="CollectionAccount.IsFrozen"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionAccountFragment WithIsFrozen(bool isIncluded = true)
    {
        return WithField("isFrozen", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Collection"/> fragment to be used for getting the <see cref="CollectionAccount.Collection"/>
    /// property of the <see cref="CollectionAccount"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Collection"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionAccountFragment WithCollection(CollectionFragment? fragment)
    {
        return WithField("collection", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="CollectionAccount.Wallet"/>
    /// property of the <see cref="CollectionAccount"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionAccountFragment WithWallet(WalletFragment? fragment)
    {
        return WithField("wallet", fragment);
    }

    /// <summary>
    /// Sets the <see cref="CollectionAccountApproval"/> fragment to be used for getting the
    /// <see cref="CollectionAccount.Approvals"/> property of the <see cref="CollectionAccount"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="CollectionAccountApproval"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionAccountFragment WithApprovals(CollectionAccountApprovalFragment? fragment)
    {
        return WithField("approvals", fragment);
    }
}