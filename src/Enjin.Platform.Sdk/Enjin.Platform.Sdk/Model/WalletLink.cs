using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a linking code used to associate an external ID to a wallet account.
/// </summary>
[PublicAPI]
public class WalletLink
{
    /// <summary>
    /// The code a user can input into the wallet app to link their account on the platform.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("code")]
    public string? Code { get; private set; }
}