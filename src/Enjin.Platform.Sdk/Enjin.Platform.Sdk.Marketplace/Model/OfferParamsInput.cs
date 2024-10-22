using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models a parameter for an offer.
/// </summary>
[PublicAPI]
public class OfferParamsInput : GraphQlParameter<OfferParamsInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfferParamsInput"/> class.
    /// </summary>
    public OfferParamsInput()
    {
    }

    /// <summary>
    /// Sets the offer expiration time.
    /// </summary>
    /// <param name="expiration">The expiration time.</param>
    /// <returns>This parameter for chaining.</returns>
    public OfferParamsInput SetExpiration(int? expiration)
    {
        return SetParameter("expiration", expiration);
    }
}