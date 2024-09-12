using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of an <see cref="AccountRequest"/> returned by the platform.
/// </summary>
[PublicAPI]
public class AccountRequestFragment : GraphQlFragment<AccountRequestFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountRequestFragment"/> class.
    /// </summary>
    public AccountRequestFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="AccountRequest"/> is to be returned with its <see cref="AccountRequest.QrCode"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AccountRequestFragment WithQrCode(bool isIncluded = true)
    {
        return WithField("qrCode", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="AccountRequest"/> is to be returned with its <see cref="AccountRequest.ProofUrl"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AccountRequestFragment WithProofUrl(bool isIncluded = true)
    {
        return WithField("proofUrl", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="AccountRequest"/> is to be returned with its <see cref="AccountRequest.ProofCode"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AccountRequestFragment WithProofCode(bool isIncluded = true)
    {
        return WithField("proofCode", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="AccountRequest"/> is to be returned with its
    /// <see cref="AccountRequest.VerificationId"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AccountRequestFragment WithVerificationId(bool isIncluded = true)
    {
        return WithField("verificationId", isIncluded);
    }
}