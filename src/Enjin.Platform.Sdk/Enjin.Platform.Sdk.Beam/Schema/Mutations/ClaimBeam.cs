using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request to act as a mutation for claiming a beam.
/// </summary>
[PublicAPI]
public class ClaimBeam : GraphQlRequest<ClaimBeam>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClaimBeam"/> class.
    /// </summary>
    public ClaimBeam() : base("ClaimBeam", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the code of the beam to claim.
    /// </summary>
    /// <param name="code">The beam code.</param>
    /// <returns>This request for chaining.</returns>
    public ClaimBeam SetCode(string? code)
    {
        return SetVariable("code", CoreTypes.String, code);
    }

    /// <summary>
    /// Sets the wallet account.
    /// </summary>
    /// <param name="account">The wallet account.</param>
    /// <returns>This request for chaining.</returns>
    public ClaimBeam SetAccount(string? account)
    {
        return SetVariable("account", CoreTypes.String, account);
    }

    /// <summary>
    /// Sets the signed message.
    /// </summary>
    /// <param name="signature">The signed message.</param>
    /// <returns>This request for chaining.</returns>
    public ClaimBeam SetSignature(string? signature)
    {
        return SetVariable("signature", CoreTypes.String, signature);
    }

    /// <summary>
    /// Sets the crypto type of signature.
    /// </summary>
    /// <param name="cryptoSignatureType">The signature's crypto type.</param>
    /// <returns>This request for chaining.</returns>
    /// <remarks>
    /// If not set or <c>null</c>, then the platform may default this argument to
    /// <see cref="CryptoSignatureType.Sr25519"/>.
    /// </remarks>
    public ClaimBeam SetCryptoSignatureType(CryptoSignatureType? cryptoSignatureType)
    {
        return SetVariable("cryptoSignatureType", CoreTypes.CryptoSignatureType, cryptoSignatureType);
    }
}