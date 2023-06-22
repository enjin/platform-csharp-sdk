using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for a ERC1155 style token ID.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<Erc1155EncoderInput>))]
[PublicAPI]
public class Erc1155EncoderInput : GraphQlParameter<Erc1155EncoderInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Erc1155EncoderInput"/> class.
    /// </summary>
    public Erc1155EncoderInput()
    {
    }

    /// <summary>
    /// Sets the 16 character hex formatted ERC1155 style token ID.
    /// </summary>
    /// <param name="tokenId">The token ID.</param>
    /// <returns>This parameter for chaining.</returns>
    public Erc1155EncoderInput SetTokenId(string? tokenId)
    {
        return SetParameter("tokenId", tokenId);
    }

    /// <summary>
    /// Sets the 64-bit integer index.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <returns>This parameter for chaining.</returns>
    /// <remarks>
    /// <para>
    /// This will be converted to hex and concatenated with the token ID to make the final unique NFT ID.
    /// </para>
    /// <para>
    /// Defaults to 0 if not supplied.
    /// </para>
    /// </remarks>
    public Erc1155EncoderInput SetIndex(BigInteger? index)
    {
        return SetParameter("index", index);
    }
}