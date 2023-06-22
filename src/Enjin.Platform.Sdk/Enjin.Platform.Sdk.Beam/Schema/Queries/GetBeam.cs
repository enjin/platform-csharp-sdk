using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request for querying a beam.
/// </summary>
/// <seealso cref="Beam"/>
[PublicAPI]
public class GetBeam : GraphQlRequest<GetBeam, BeamFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetBeam"/> class.
    /// </summary>
    public GetBeam() : base("GetBeam", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the beam code.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns>This request for chaining.</returns>
    public GetBeam SetCode(string? code)
    {
        return SetVariable("code", CoreTypes.String, code);
    }

    /// <summary>
    /// Sets the wallet account.
    /// </summary>
    /// <param name="account">The wallet account.</param>
    /// <returns>This request for chaining.</returns>
    public GetBeam SetAccount(string? account)
    {
        return SetVariable("account", CoreTypes.String, account);
    }
}