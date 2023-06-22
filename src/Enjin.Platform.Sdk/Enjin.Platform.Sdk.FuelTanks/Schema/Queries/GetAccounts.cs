using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request for querying the wallet accounts of a fuel tank.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="WalletFragment"/>
[PublicAPI]
public class GetAccounts : GraphQlRequest<GetAccounts, WalletConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetAccounts"/> class.
    /// </summary>
    public GetAccounts() : base("GetAccounts", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address of the fuel tank.</param>
    /// <returns>This request for chaining.</returns>
    public GetAccounts SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }
}