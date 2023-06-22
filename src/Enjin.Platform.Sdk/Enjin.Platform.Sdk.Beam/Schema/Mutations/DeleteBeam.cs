using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request to act as a mutation for deleting a beam.
/// </summary>
[PublicAPI]
public class DeleteBeam : GraphQlRequest<DeleteBeam>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteBeam"/> class.
    /// </summary>
    public DeleteBeam() : base("DeleteBeam", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the beam code.
    /// </summary>
    /// <param name="code">The beam code.</param>
    /// <returns>This request for chaining.</returns>
    public DeleteBeam SetCode(string? code)
    {
        return SetVariable("code", CoreTypes.String, code);
    }
}