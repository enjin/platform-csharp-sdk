using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="Wallet"/> returned by the platform.
/// </summary>
[PublicAPI]
public class WalletFragment : GraphQlFragment<WalletFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WalletFragment"/> class.
    /// </summary>
    public WalletFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Wallet"/> is to be returned with its <see cref="Wallet.Id"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Account"/> fragment to be used for getting the <see cref="Wallet.Account"/> property of the
    /// <see cref="Wallet"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Account"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithAccount(AccountFragment? fragment)
    {
        return WithField("account", fragment);
    }

    /// <summary>
    /// Sets whether the <see cref="Wallet"/> is to be returned with its <see cref="Wallet.ExternalId"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithExternalId(bool isIncluded = true)
    {
        return WithField("externalId", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Wallet"/> is to be returned with its <see cref="Wallet.Managed"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithManaged(bool isIncluded = true)
    {
        return WithField("managed", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Wallet"/> is to be returned with its <see cref="Wallet.Network"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithNetwork(bool isIncluded = true)
    {
        return WithField("network", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Wallet"/> is to be returned with its <see cref="Wallet.Nonce"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithNonce(bool isIncluded = true)
    {
        return WithField("nonce", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Balances"/> fragment to be used for getting the <see cref="Wallet.Account"/> property of the
    /// <see cref="Wallet"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Balances"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithBalances(BalancesFragment? fragment)
    {
        return WithField("balances", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="CollectionAccount"/>, to be used for
    /// getting the <see cref="Wallet.CollectionAccounts"/> property of the <see cref="Wallet"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="CollectionAccount"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithCollectionAccounts(CollectionAccountConnectionFragment? fragment)
    {
        return WithField("collectionAccounts", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="TokenAccount"/>, to be used for getting the
    /// <see cref="Wallet.TokenAccounts"/> property of the <see cref="Wallet"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="TokenAccount"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithTokenAccounts(TokenAccountConnectionFragment? fragment)
    {
        return WithField("tokenAccounts", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="CollectionAccountApproval"/>, to be used
    /// for getting the <see cref="Wallet.CollectionAccountApprovals"/> property of the <see cref="Wallet"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="CollectionAccountApproval"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithCollectionAccountApprovals(CollectionAccountApprovalConnectionFragment? fragment)
    {
        return WithField("collectionAccountApprovals", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="TokenAccountApproval"/>, to be used for
    /// getting the <see cref="Wallet.TokenAccountApprovals"/> property of the <see cref="Wallet"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="TokenAccountApproval"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithTokenAccountApprovals(TokenAccountApprovalConnectionFragment? fragment)
    {
        return WithField("tokenAccountApprovals", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="Transaction"/>, to be used for getting the
    /// <see cref="Wallet.Transactions"/> property of the <see cref="Wallet"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="Transaction"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithTransactions(TransactionConnectionFragment? fragment)
    {
        return WithField("transactions", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="Collection"/>, to be used for getting the
    /// <see cref="Wallet.OwnedCollections"/> property of the <see cref="Wallet"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="Collection"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public WalletFragment WithOwnedCollections(CollectionConnectionFragment? fragment)
    {
        return WithField("ownedCollections", fragment);
    }
}