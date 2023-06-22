using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for a recipient account for a mint.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<MintRecipient>))]
[PublicAPI]
public class MintRecipient : GraphQlParameter<MintRecipient>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MintRecipient"/> class.
    /// </summary>
    public MintRecipient()
    {
    }

    /// <summary>
    /// Sets the recipient account of the token.
    /// </summary>
    /// <param name="account">The account.</param>
    /// <returns>This parameter for chaining.</returns>
    public MintRecipient SetAccount(string? account)
    {
        return SetParameter("account", account);
    }

    /// <summary>
    /// Sets the parameters to create a token.
    /// </summary>
    /// <param name="createParams">The parameters.</param>
    /// <returns>This parameter for chaining.</returns>
    public MintRecipient SetCreateParams(CreateTokenParams? createParams)
    {
        return SetParameter("createParams", createParams);
    }

    /// <summary>
    /// Sets the parameters to mint a token.
    /// </summary>
    /// <param name="mintParams">The parameters.</param>
    /// <returns>This parameter for chaining.</returns>
    public MintRecipient SetMintParams(MintTokenParams? mintParams)
    {
        return SetParameter("mintParams", mintParams);
    }
}