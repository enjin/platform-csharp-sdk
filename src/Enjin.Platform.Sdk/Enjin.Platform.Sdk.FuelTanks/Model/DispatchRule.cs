using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// The dispatch rules for a fuel tank.
/// </summary>
[PublicAPI]
public class DispatchRule
{
    /// <summary>
    /// The fuel tank rule.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("rule")]
    public string? Rule { get; private set; }

    /// <summary>
    /// The rule set ID.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("ruleSetId")]
    public int? RuleSetId { get; private set; }

    /// <summary>
    /// The rule value.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("value")]
    public JsonElement? Value { get; private set; }

    /// <summary>
    /// Whether the dispatch is frozen.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("isFrozen")]
    public bool? IsFrozen { get; private set; }
}