using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request for querying pending claims.
/// </summary>
[PublicAPI]
public class GetPendingClaims : GraphQlRequest<GetPendingClaims, BeamClaimConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetPendingClaims"/> class.
    /// </summary>
    public GetPendingClaims() : base("GetPendingClaims", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the beam code.
    /// </summary>
    /// <param name="code">The beam code.</param>
    /// <returns>This request for chaining.</returns>
    public GetPendingClaims SetCode(string? code)
    {
        return SetVariable("code", CoreTypes.String, code);
    }
    
    /// <summary>
    /// Sets the beam code.
    /// </summary>
    /// <param name="account">The account to get claims for.</param>
    /// <returns>This request for chaining.</returns>
    public GetPendingClaims SetAccount(string? account)
    {
        return SetVariable("account", CoreTypes.String, account);
    }
}