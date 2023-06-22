using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models the location of where an error in a GraphQL request occurred.
/// </summary>
[PublicAPI]
public class GraphQlErrorLocation
{
    /// <summary>
    /// The line in the request where the error occurred.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("line")]
    public int Line { get; private set; }

    /// <summary>
    /// The column in the request where the error occurred.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("column")]
    public int Column { get; private set; }
}