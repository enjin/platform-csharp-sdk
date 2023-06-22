using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Models account rules for a fuel tank.
/// </summary>
[PublicAPI]
public class AccountRule
{
    /// <summary>
    /// The fuel tank rule.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("rule")]
    public string? Rule { get; private set; }

    /// <summary>
    /// The rule value.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("value")]
    public JsonElement? Value { get; private set; }
}