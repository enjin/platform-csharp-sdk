using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request to act as a mutation for updating a beam.
/// </summary>
[PublicAPI]
public class UpdateBeam : GraphQlRequest<UpdateBeam>,
                          IHasBeamCommonFields<UpdateBeam>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateBeam"/> class.
    /// </summary>
    public UpdateBeam() : base("UpdateBeam", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the code of the beam to update.
    /// </summary>
    /// <param name="code">The beam code.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateBeam SetCode(string? code)
    {
        return SetVariable("code", CoreTypes.String, code);
    }
    
    /// <summary>
    /// Sets the source account for tokens.
    /// </summary>
    /// <param name="source">The source account.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateBeam SetSource(string? source)
    {
        return SetVariable("source", CoreTypes.String, source);
    }

    /// <summary>
    /// Sets the beam flags that should be enabled or disabled.
    /// </summary>
    /// <param name="flags">The flags.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateBeam SetFlags(params BeamFlagInputType[]? flags)
    {
        return SetVariable("flags", BeamTypes.BeamFlagInputTypeArray, flags);
    }
    
    /// <summary>
    /// Sets the token IDs to add.
    /// </summary>
    /// <param name="tokenIds">The token claims to add.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateBeam SetTokens(params ClaimToken[]? tokenIds)
    {
        return SetVariable("tokens", BeamTypes.ClaimTokenArray, tokenIds);
    }
}