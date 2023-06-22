using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models the parameter for the mint policy for a new collection.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<MintPolicy>))]
[PublicAPI]
public class MintPolicy : GraphQlParameter<MintPolicy>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MintPolicy"/> class.
    /// </summary>
    public MintPolicy()
    {
    }

    /// <summary>
    /// Sets the maximum number of tokens that can be issued for the collection.
    /// </summary>
    /// <param name="maxTokenCount">The maximum number of tokens.</param>
    /// <returns>This parameter for chaining.</returns>
    public MintPolicy SetMaxTokenCount(BigInteger? maxTokenCount)
    {
        return SetParameter("maxTokenCount", maxTokenCount);
    }

    /// <summary>
    /// Sets the maximum amount of each token in the collection that can be minted.
    /// </summary>
    /// <param name="maxTokenSupply">The maximum amount per token.</param>
    /// <returns>This parameter for chaining.</returns>
    public MintPolicy SetMaxTokenSupply(BigInteger? maxTokenSupply)
    {
        return SetParameter("maxTokenSupply", maxTokenSupply);
    }

    /// <summary>
    /// Set whether the tokens in the collection will be minted as single mint types. This would indicate the tokens in
    /// the collection are non-fungible tokens (NFTs).
    /// </summary>
    /// <param name="forceSingleMint">Whether the tokens are non-fungible.</param>
    /// <returns>This parameter for chaining.</returns>
    public MintPolicy SetForceSingleMint(bool? forceSingleMint)
    {
        return SetParameter("forceSingleMint", forceSingleMint);
    }
}