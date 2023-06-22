using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for setting the recipient account of a transfer.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<TransferRecipient>))]
[PublicAPI]
public class TransferRecipient : GraphQlParameter<TransferRecipient>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransferRecipient"/> class.
    /// </summary>
    public TransferRecipient()
    {
    }

    /// <summary>
    /// Sets the recipient account of the token.
    /// </summary>
    /// <param name="account">The recipient account.</param>
    /// <returns>This parameter for chaining.</returns>
    public TransferRecipient SetAccount(string? account)
    {
        return SetParameter("account", account);
    }

    /// <summary>
    /// Sets parameters for making a simple transfer.
    /// </summary>
    /// <param name="simpleParams">The parameters.</param>
    /// <returns>This parameter for chaining.</returns>
    public TransferRecipient SetSimpleParams(SimpleTransferParams? simpleParams)
    {
        return SetParameter("simpleParams", simpleParams);
    }

    /// <summary>
    /// Sets parameters for making an operator transfer.
    /// </summary>
    /// <param name="operatorParams">The parameters.</param>
    /// <returns>This parameter for chaining.</returns>
    public TransferRecipient SetOperatorParams(OperatorTransferParams? operatorParams)
    {
        return SetParameter("operatorParams", operatorParams);
    }
}