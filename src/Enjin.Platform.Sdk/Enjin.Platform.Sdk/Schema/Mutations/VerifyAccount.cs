using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation that the wallet calls to prove the ownership of the user account.
/// </summary>
[PublicAPI]
public class VerifyAccount : GraphQlRequest<VerifyAccount>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VerifyAccount"/> class.
    /// </summary>
    public VerifyAccount() : base("VerifyAccount", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the verification ID.
    /// </summary>
    /// <param name="verificationId">The verification ID.</param>
    /// <returns>This request for chaining.</returns>
    public VerifyAccount SetVerificationId(string? verificationId)
    {
        return SetVariable("verificationId", CoreTypes.String, verificationId);
    }

    /// <summary>
    /// Sets the signature.
    /// </summary>
    /// <param name="signature">The signature.</param>
    /// <returns>This request for chaining.</returns>
    public VerifyAccount SetSignature(string? signature)
    {
        return SetVariable("signature", CoreTypes.String, signature);
    }

    /// <summary>
    /// Sets the account.
    /// </summary>
    /// <param name="account">The account.</param>
    /// <returns>This request for chaining.</returns>
    public VerifyAccount SetAccount(string? account)
    {
        return SetVariable("account", CoreTypes.String, account);
    }

    /// <summary>
    /// Sets the signature crypto type.
    /// </summary>
    /// <param name="cryptoSignatureType">The signature crypto type.</param>
    /// <returns>This request for chaining.</returns>
    /// <remarks>
    /// Defaults to <see cref="CryptoSignatureType.Ed25519"/> on the platform if not set.
    /// </remarks>
    public VerifyAccount SetCryptoSignatureType(CryptoSignatureType? cryptoSignatureType)
    {
        return SetVariable("cryptoSignatureType", CoreTypes.CryptoSignatureType, cryptoSignatureType);
    }
}