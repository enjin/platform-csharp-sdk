using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request for querying an array of beams optionally filtered by .
/// </summary>
[PublicAPI]
public class GetBeams : GraphQlRequest<GetBeams, BeamConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetBeams"/> class.
    /// </summary>
    public GetBeams() : base("GetBeams", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the beam codes.
    /// </summary>
    /// <param name="codes">The codes.</param>
    /// <returns>This request for chaining.</returns>
    public GetBeams SetCodes(params string[]? codes)
    {
        return SetVariable("codes", CoreTypes.StringArray, codes);
    }

    /// <summary>
    /// Sets the names.
    /// </summary>
    /// <param name="names">The names.</param>
    /// <returns>This request for chaining.</returns>
    public GetBeams SetNames(params string[]? names)
    {
        return SetVariable("names", CoreTypes.StringArray, names);
    }
}