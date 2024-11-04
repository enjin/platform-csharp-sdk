using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request to act as a mutation for updating a beam.
/// </summary>
[PublicAPI]
public class UpdateBeamWhitelist : GraphQlRequest<UpdateBeamWhitelist>,
                          IHasBeamCommonFields<UpdateBeamWhitelist>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateBeamWhitelist"/> class.
    /// </summary>
    public UpdateBeamWhitelist() : base("UpdateBeamWhitelist", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the code of the beam to update.
    /// </summary>
    /// <param name="code">The beam code.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateBeamWhitelist SetCode(string? code)
    {
        return SetVariable("code", CoreTypes.String, code);
    }
    
    /// <summary>
    /// Sets the .
    /// </summary>
    /// <param name="uuid">The UUID code.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateBeamWhitelist SetUuid(string? uuid)
    {
        return SetVariable("uuid", CoreTypes.String, uuid);
    }
    
    /// <summary>
    /// Sets the token IDs to add.
    /// </summary>
    /// <param name="claimWhitelist">The token claims to add.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateBeamWhitelist SetTokens(params string[]? claimWhitelist)
    {
        return SetVariable("claimWhitelist", CoreTypes.StringArray, claimWhitelist);
    }
}