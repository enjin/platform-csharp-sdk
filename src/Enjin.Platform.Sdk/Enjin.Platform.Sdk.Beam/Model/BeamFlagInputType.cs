using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Models a parameter for inputting a beam flag.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<BeamFlagInputType>))]
[PublicAPI]
public class BeamFlagInputType : GraphQlParameter<BeamFlagInputType>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BeamFlagInputType"/> class.
    /// </summary>
    public BeamFlagInputType()
    {
    }

    /// <summary>
    /// Sets the beam flag.
    /// </summary>
    /// <param name="flag">The beam flag.</param>
    /// <returns>This parameter for chaining.</returns>
    public BeamFlagInputType SetFlag(BeamFlag? flag)
    {
        return SetParameter("flag", flag);
    }

    /// <summary>
    /// Sets whether the flag is enabled.
    /// </summary>
    /// <param name="enabled">Whether the flag is enabled.</param>
    /// <returns>This parameter for chaining.</returns>
    public BeamFlagInputType SetEnabled(bool? enabled)
    {
        return SetParameter("enabled", enabled);
    }
}