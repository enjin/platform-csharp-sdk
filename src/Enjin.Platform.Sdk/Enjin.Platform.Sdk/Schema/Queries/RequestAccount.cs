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
}