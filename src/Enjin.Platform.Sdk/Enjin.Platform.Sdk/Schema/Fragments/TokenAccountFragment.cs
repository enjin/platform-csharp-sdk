using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="TokenAccount"/> returned by the platform.
/// </summary>
[PublicAPI]
public class TokenAccountFragment : GraphQlFragment<TokenAccountFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenAccountFragment"/> class.
    /// </summary>
    public TokenAccountFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="TokenAccount"/> is to be returned with its <see cref="TokenAccount.Balance"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountFragment WithBalance(bool isIncluded = true)
    {
        return WithField("balance", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="TokenAccount"/> is to be returned with its
    /// <see cref="TokenAccount.ReservedBalance"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountFragment WithReservedBalance(bool isIncluded = true)
    {
        return WithField("reservedBalance", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="TokenAccount"/> is to be returned with its <see cref="TokenAccount.IsFrozen"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountFragment WithIsFrozen(bool isIncluded = true)
    {
        return WithField("isFrozen", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Collection"/> fragment to be used for getting the <see cref="TokenAccount.Collection"/>
    /// property of the <see cref="TokenAccount"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Collection"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountFragment WithCollection(CollectionFragment? fragment)
    {
        return WithField("collection", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="TokenAccount.Wallet"/> property of
    /// the <see cref="TokenAccount"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountFragment WithWallet(WalletFragment? fragment)
    {
        return WithField("wallet", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Token"/> fragment to be used for getting the <see cref="TokenAccount.Token"/> property of
    /// the <see cref="TokenAccount"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Token"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountFragment WithToken(TokenFragment? fragment)
    {
        return WithField("token", fragment);
    }

    /// <summary>
    /// Sets the <see cref="TokenAccountApproval"/> fragment to be used for getting the
    /// <see cref="TokenAccount.Approvals"/> property of the <see cref="TokenAccount"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="TokenAccountApproval"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountFragment WithApprovals(TokenAccountApprovalFragment? fragment)
    {
        return WithField("approvals", fragment);
    }

    /// <summary>
    /// Sets the <see cref="TokenAccountNamedReserve"/> fragment to be used for getting the
    /// <see cref="TokenAccount.NamedReserves"/> property of the <see cref="TokenAccount"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="TokenAccountNamedReserve"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenAccountFragment WithNamedReserves(TokenAccountNamedReserveFragment? fragment)
    {
        return WithField("namedReserves", fragment);
    }
}