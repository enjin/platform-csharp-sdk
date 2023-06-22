using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a substrate account.
/// </summary>
[PublicAPI]
public class Account
{
    /// <summary>
    /// The public key of this account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("publicKey")]
    public string? PublicKey { get; private set; }

    /// <summary>
    /// The address of this account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("address")]
    public string? Address { get; private set; }
}