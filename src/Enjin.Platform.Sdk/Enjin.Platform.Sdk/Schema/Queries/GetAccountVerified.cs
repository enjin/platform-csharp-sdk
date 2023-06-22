using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying the verification status of an account.
/// </summary>
/// <seealso cref="AccountVerified"/>
[PublicAPI]
public class GetAccountVerified : GraphQlRequest<GetAccountVerified, AccountVerifiedFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetAccountVerified"/> class.
    /// </summary>
    public GetAccountVerified() : base("GetAccountVerified", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the verification ID to be checked.
    /// </summary>
    /// <param name="verificationId">The verification ID.</param>
    /// <returns>This requesting for chaining.</returns>
    public GetAccountVerified SetVerificationId(string? verificationId)
    {
        return SetVariable("verificationId", CoreTypes.String, verificationId);
    }

    /// <summary>
    /// Sets the wallet account to be checked.
    /// </summary>
    /// <param name="account">The wallet account.</param>
    /// <returns>This requesting for chaining.</returns>
    public GetAccountVerified SetAccount(string? account)
    {
        return SetVariable("account", CoreTypes.String, account);
    }
}