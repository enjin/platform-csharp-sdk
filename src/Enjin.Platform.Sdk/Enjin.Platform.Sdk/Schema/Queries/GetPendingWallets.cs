using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying an array of wallet accounts which have yet to be verified.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="Wallet"/>
[PublicAPI]
public class GetPendingWallets : GraphQlRequest<GetPendingWallets, WalletConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetPendingWallets"/> class.
    /// </summary>
    public GetPendingWallets() : base("GetPendingWallets", GraphQlRequestType.Query)
    {
    }
}