using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a request to verify an <see cref="Account"/>.
/// </summary>
[PublicAPI]
public class AccountRequest
{
    /// <summary>
    /// The QR code a user can scan in the wallet app to verify their account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("qrCode")]
    public string? QrCode { get; private set; }
    
    /// <summary>
    /// The proof URL to use instead of (or alongside) the QR Code
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("proofUrl")]
    public string? ProofUrl { get; private set; }
    
    /// <summary>
    /// The proof code for this request.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("proofCode")]
    public string? ProofCode { get; private set; }

    /// <summary>
    /// The verification ID generated to get the account from.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("verificationId")]
    public string? VerificationId { get; private set; }
}