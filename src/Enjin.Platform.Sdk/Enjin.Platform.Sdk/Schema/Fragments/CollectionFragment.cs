using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="Collection"/> returned by the platform.
/// </summary>
[PublicAPI]
public class CollectionFragment : GraphQlFragment<CollectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionFragment"/> class.
    /// </summary>
    public CollectionFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Collection"/> is to be returned with its <see cref="Collection.CollectionId"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithCollectionId(bool isIncluded = true)
    {
        return WithField("collectionId", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Collection"/> is to be returned with its <see cref="Collection.MaxTokenCount"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithMaxTokenCount(bool isIncluded = true)
    {
        return WithField("maxTokenCount", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Collection"/> is to be returned with its <see cref="Collection.MaxTokenSupply"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithMaxTokenSupply(bool isIncluded = true)
    {
        return WithField("maxTokenSupply", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Collection"/> is to be returned with its <see cref="Collection.ForceCollapsingSupply"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithForceCollapsingSupply(bool isIncluded = true)
    {
        return WithField("forceCollapsingSupply", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Collection"/> is to be returned with its <see cref="Collection.Frozen"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithFrozen(bool isIncluded = true)
    {
        return WithField("frozen", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Royalty"/> fragment to be used for getting the <see cref="Collection.Royalty"/> property of
    /// the <see cref="Collection"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Royalty"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithRoyalty(RoyaltyFragment? fragment)
    {
        return WithField("royalty", fragment);
    }
    
    /// <summary>
    /// Sets whether the <see cref="Collection"/> is to be returned with its <see cref="Collection.TotalDeposit"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithTotalDeposit(bool isIncluded = true)
    {
        return WithField("totalDeposit", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="Collection"/> is to be returned with its <see cref="Collection.TotalInfusion"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithTotalInfusion(bool isIncluded = true)
    {
        return WithField("totalInfusion", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="Collection"/> is to be returned with its <see cref="Collection.CreationDeposit"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithCreationDeposit(bool isIncluded = true)
    {
        return WithField("creationDeposit", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Collection"/> is to be returned with its <see cref="Collection.Network"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithNetwork(bool isIncluded = true)
    {
        return WithField("network", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Collection.Owner"/> property of the
    /// <see cref="Collection"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithOwner(WalletFragment? fragment)
    {
        return WithField("owner", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Attribute"/> fragment to be used for getting the <see cref="Collection.Attributes"/>
    /// property of the <see cref="Collection"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Attribute"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithAttributes(AttributeFragment? fragment)
    {
        return WithField("attributes", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="CollectionAccount"/>, to be used for
    /// getting the <see cref="Collection.Accounts"/> property of the <see cref="Collection"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="CollectionAccount"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithAccounts(CollectionAccountConnectionFragment? fragment)
    {
        return WithField("accounts", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="Token"/>, to be used for getting the
    /// <see cref="Collection.Tokens"/> property of the <see cref="Collection"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="Token"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public CollectionFragment WithTokens(TokenConnectionFragment? fragment)
    {
        return WithField("tokens", fragment);
    }
}