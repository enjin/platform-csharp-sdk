using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="Token"/> returned by the platform.
/// </summary>
[PublicAPI]
public class TokenFragment : GraphQlFragment<TokenFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenFragment"/> class.
    /// </summary>
    public TokenFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.TokenId"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithTokenId(bool isIncluded = true)
    {
        return WithField("tokenId", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.Supply"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithSupply(bool isIncluded = true)
    {
        return WithField("supply", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.Cap"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithCap(bool isIncluded = true)
    {
        return WithField("cap", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.CapSupply"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithCapSupply(bool isIncluded = true)
    {
        return WithField("capSupply", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.IsFrozen"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithIsFrozen(bool isIncluded = true)
    {
        return WithField("isFrozen", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.IsCurrency"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithIsCurrency(bool isIncluded = true)
    {
        return WithField("isCurrency", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Royalty"/> fragment to be used for getting the <see cref="Token.Royalty"/> property of the
    /// <see cref="Token"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Royalty"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithRoyalty(RoyaltyFragment? fragment)
    {
        return WithField("royalty", fragment);
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.MinimumBalance"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithMinimumBalance(bool isIncluded = true)
    {
        return WithField("minimumBalance", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.UnitPrice"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithUnitPrice(bool isIncluded = true)
    {
        return WithField("unitPrice", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.AttributeCount"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithAttributeCount(bool isIncluded = true)
    {
        return WithField("attributeCount", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Collection"/> fragment to be used for getting the <see cref="Token.Collection"/> property of
    /// the <see cref="Token"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Collection"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithCollection(CollectionFragment? fragment)
    {
        return WithField("collection", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Attribute"/> fragment to be used for getting the <see cref="Token.Attributes"/> property of
    /// the <see cref="Token"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Attribute"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithAttributes(AttributeFragment? fragment)
    {
        return WithField("attributes", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="TokenAccount"/>, to be used for getting the
    /// <see cref="Token.Accounts"/> property of the <see cref="Token"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Connection{T}"/> fragment, which uses <see cref="TokenAccount"/>.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithAccounts(TokenAccountConnectionFragment? fragment)
    {
        return WithField("accounts", fragment);
    }
    
    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.MintDeposit"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithMintDeposit(bool isIncluded = true)
    {
        return WithField("mintDeposit", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.Metadata"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithMetadata(bool isIncluded = true)
    {
        return WithField("metadata", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Token"/> is to be returned with its <see cref="Token.NonFungible"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenFragment WithNonFungible(bool isIncluded = true)
    {
        return WithField("nonFungible", isIncluded);
    }
}