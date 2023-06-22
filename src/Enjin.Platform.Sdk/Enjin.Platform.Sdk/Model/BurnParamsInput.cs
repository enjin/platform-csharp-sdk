using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for the parameters to burn a token.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<BurnParamsInput>))]
[PublicAPI]
public class BurnParamsInput : GraphQlParameter<BurnParamsInput>,
                               IHasEncodableTokenId<BurnParamsInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BurnParamsInput"/> class.
    /// </summary>
    public BurnParamsInput()
    {
    }

    /// <summary>
    /// Sets the amount to transfer.
    /// </summary>
    /// <param name="amount">The amount to transfer.</param>
    /// <returns>This parameter for chaining.</returns>
    public BurnParamsInput SetAmount(BigInteger? amount)
    {
        return SetParameter("amount", amount);
    }

    /// <summary>
    /// Sets whether the transaction will be kept from failing if the balance drops below the minimum requirement.
    /// </summary>
    /// <param name="keepAlive">Whether the transaction will be kept from failing.</param>
    /// <returns>This parameter for chaining.</returns>
    public BurnParamsInput SetKeepAlive(bool? keepAlive)
    {
        return SetParameter("keepAlive", keepAlive);
    }

    /// <summary>
    /// Sets whether the token storage will be removed if no tokens are left.
    /// </summary>
    /// <param name="removeTokenStorage">Whether the token storage will be removed.</param>
    /// <returns>This parameter for chaining.</returns>
    public BurnParamsInput SetRemoveTokenStorage(bool? removeTokenStorage)
    {
        return SetParameter("removeTokenStorage", removeTokenStorage);
    }
}