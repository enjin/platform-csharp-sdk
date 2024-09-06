using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Models a parameter for requiring a signature.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<RequireSignatureInputType>))]
[PublicAPI]
public class RequireSignatureInputType : GraphQlParameter<RequireSignatureInputType>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RequireSignatureInputType"/> class.
    /// </summary>
    public RequireSignatureInputType()
    {
    }

    /// <summary>
    /// Sets the amount of fuel.
    /// </summary>
    /// <param name="signature">The signature.</param>
    /// <returns>This parameter for chaining.</returns>
    public RequireSignatureInputType SetSignature(string signature)
    {
        return SetParameter("signature", signature);
    }
}