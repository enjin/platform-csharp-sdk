using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for generating a QR code that a user can scan to request an account for their wallet.
/// </summary>
/// <seealso cref="AccountRequest"/>
[PublicAPI]
public class RequestAccount : GraphQlRequest<RequestAccount, AccountRequestFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RequestAccount"/> class.
    /// </summary>
    public RequestAccount() : base("RequestAccount", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the callback URL that the wallet should send the verification to.
    /// </summary>
    /// <param name="callback">The callback URL.</param>
    /// <returns>This request for chaining.</returns>
    public RequestAccount SetCallback(string? callback)
    {
        return SetVariable("callback", CoreTypes.String, callback);
    }
}