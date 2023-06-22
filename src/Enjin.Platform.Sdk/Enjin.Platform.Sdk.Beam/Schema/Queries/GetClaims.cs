using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request for querying claim details.
/// </summary>
[PublicAPI]
public class GetClaims : GraphQlRequest<GetClaims, BeamClaimConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetClaims"/> class.
    /// </summary>
    public GetClaims() : base("GetClaims", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the internal IDs.
    /// </summary>
    /// <param name="ids">The internal IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetClaims SetIds(params BigInteger[]? ids)
    {
        return SetVariable("ids", CoreTypes.BigIntArray, ids);
    }

    /// <summary>
    /// Sets the beam codes.
    /// </summary>
    /// <param name="codes">The beam codes.</param>
    /// <returns>This request for chaining.</returns>
    public GetClaims SetCodes(params string[]? codes)
    {
        return SetVariable("codes", CoreTypes.StringArray, codes);
    }

    /// <summary>
    /// Sets the wallet accounts.
    /// </summary>
    /// <param name="accounts">The wallet accounts.</param>
    /// <returns>This request for chaining.</returns>
    public GetClaims SetAccounts(params string[]? accounts)
    {
        return SetVariable("accounts", CoreTypes.StringArray, accounts);
    }

    /// <summary>
    /// Sets the claim statuses.
    /// </summary>
    /// <param name="states">The claim statuses.</param>
    /// <returns>This request for chaining.</returns>
    public GetClaims SetStates(params ClaimStatus[]? states)
    {
        return SetVariable("states", BeamTypes.ClaimStatusArray, states);
    }
}