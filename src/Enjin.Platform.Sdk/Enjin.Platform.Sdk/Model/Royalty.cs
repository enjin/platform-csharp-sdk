using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a royalty policy.
/// </summary>
[PublicAPI]
public class Royalty
{
    /// <summary>
    /// The benefactor of this royalty.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("beneficiary")]
    public Wallet? Beneficiary { get; private set; }

    /// <summary>
    /// The percentage of this royalty.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("percentage")]
    public double? Percentage { get; private set; }
}