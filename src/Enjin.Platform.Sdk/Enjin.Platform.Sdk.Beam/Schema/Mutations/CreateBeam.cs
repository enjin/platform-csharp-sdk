using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request to act as a mutation for creating a beam.
/// </summary>
[PublicAPI]
public class CreateBeam : GraphQlRequest<CreateBeam>,
                          IHasBeamCommonFields<CreateBeam>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateBeam"/> class.
    /// </summary>
    public CreateBeam() : base("CreateBeam", GraphQlRequestType.Mutation)
    {
    }
    
    /// <summary>
    /// Sets the source account for tokens.
    /// </summary>
    /// <param name="source">The source account.</param>
    /// <returns>This request for chaining.</returns>
    public CreateBeam SetSource(string? source)
    {
        return SetVariable("source", CoreTypes.String, source);
    }

    /// <summary>
    /// Sets the beam flags that should be enabled or disabled.
    /// </summary>
    /// <param name="flags">The beam flags.</param>
    /// <returns>This request for chaining.</returns>
    public CreateBeam SetFlags(params BeamFlagInputType[]? flags)
    {
        return SetVariable("flags", BeamTypes.BeamFlagInputTypeArray, flags);
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public CreateBeam SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the claimable tokens.
    /// </summary>
    /// <param name="tokens">The claimable tokens.</param>
    /// <returns>This request for chaining.</returns>
    public CreateBeam SetTokens(params ClaimToken[]? tokens)
    {
        return SetVariable("tokens", BeamTypes.ClaimTokenArray, tokens);
    }
}