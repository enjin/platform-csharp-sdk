using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request for querying single use codes.
/// </summary>
[PublicAPI]
public class GetSingleUseCodes : GraphQlRequest<GetSingleUseCodes, BeamClaimConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetSingleUseCodes"/> class.
    /// </summary>
    public GetSingleUseCodes() : base("GetSingleUseCodes", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the beam code.
    /// </summary>
    /// <param name="code">The beam code.</param>
    /// <returns>This request for chaining.</returns>
    public GetSingleUseCodes SetCode(string? code)
    {
        return SetVariable("code", CoreTypes.String, code);
    }
}