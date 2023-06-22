using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models the verification status of an <see cref="Account"/>.
/// </summary>
[PublicAPI]
public class AccountVerified
{
    /// <summary>
    /// Whether the user account has already been verified.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("verified")]
    public bool? Verified { get; private set; }

    /// <summary>
    /// The account that was verified.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("account")]
    public Account? Account { get; private set; }
}