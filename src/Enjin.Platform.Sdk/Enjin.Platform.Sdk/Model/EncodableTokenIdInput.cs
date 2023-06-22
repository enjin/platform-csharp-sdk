using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for setting parameters to encode a token ID.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<EncodableTokenIdInput>))]
[PublicAPI]
public class EncodableTokenIdInput : GraphQlParameter<EncodableTokenIdInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EncodableTokenIdInput"/> class.
    /// </summary>
    public EncodableTokenIdInput()
    {
    }

    /// <summary>
    /// Sets an ERC1155 style token input to be used to create an integer representation.
    /// </summary>
    /// <param name="erc1155">The ERC1155 style input.</param>
    /// <returns>This parameter for chaining.</returns>
    public EncodableTokenIdInput SetErc1155(Erc1155EncoderInput? erc1155)
    {
        return SetParameter("erc1155", erc1155);
    }

    /// <summary>
    /// Sets an arbitrary object to be hashed into an integer.
    /// </summary>
    /// <param name="hash">The object to hash.</param>
    /// <returns>This parameter for chaining.</returns>
    public EncodableTokenIdInput SetHash(JsonElement? hash)
    {
        return SetParameter("hash", hash);
    }

    /// <summary>
    /// Sets a 128-bit unsigned integer.
    /// </summary>
    /// <param name="integer">The integer.</param>
    /// <returns>This parameter for chaining.</returns>
    public EncodableTokenIdInput SetInteger(BigInteger? integer)
    {
        return SetParameter("integer", integer);
    }

    /// <summary>
    /// Sets the string to be converted into the ID.
    /// </summary>
    /// <param name="stringId">The string to convert.</param>
    /// <returns>This parameter for chaining.</returns>
    /// <remarks>
    /// <para>
    /// Converts the string into a hex value, then converts the hex value into an integer.
    /// </para>
    /// <para>
    /// This encoding is reversible.
    /// </para>
    /// </remarks>
    public EncodableTokenIdInput SetStringId(string? stringId)
    {
        return SetParameter("stringId", stringId);
    }
}