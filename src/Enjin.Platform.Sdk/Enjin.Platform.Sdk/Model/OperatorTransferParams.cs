using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for parameters to make an operator transfer.
/// </summary>
/// <remarks>
/// Operator transfers are transfers that you make using tokens from somebody else's wallet as the source. To make this
/// type of transfer the source wallet owner must approve you for transferring their tokens.
/// </remarks>
[JsonConverter(typeof(GraphQlParameterJsonConverter<OperatorTransferParams>))]
[PublicAPI]
public class OperatorTransferParams : GraphQlParameter<OperatorTransferParams>,
                                      IHasEncodableTokenId<OperatorTransferParams>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorTransferParams"/> class.
    /// </summary>
    public OperatorTransferParams()
    {
    }

    /// <summary>
    /// Sets the source account of the token.
    /// </summary>
    /// <param name="source">The source account.</param>
    /// <returns>This parameter for chaining.</returns>
    public OperatorTransferParams SetSource(string? source)
    {
        return SetParameter("source", source);
    }

    /// <summary>
    /// Sets the amount to transfer.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <returns>This parameter for chaining.</returns>
    public OperatorTransferParams SetAmount(BigInteger? amount)
    {
        return SetParameter("amount", amount);
    }
}