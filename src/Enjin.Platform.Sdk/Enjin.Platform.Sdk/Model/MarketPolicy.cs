using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for the marketplace policy of a collection.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<MarketPolicy>))]
[PublicAPI]
public class MarketPolicy : GraphQlParameter<MarketPolicy>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketPolicy"/> class.
    /// </summary>
    public MarketPolicy()
    {
    }

    /// <summary>
    /// Sets the royalty for this marketplace policy.
    /// </summary>
    /// <param name="royalty">The royalty.</param>
    /// <returns>This parameter for chaining.</returns>
    public MarketPolicy SetRoyalty(RoyaltyInput? royalty)
    {
        return SetParameter("royalty", royalty);
    }
}