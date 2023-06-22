using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models the data field of a GraphQL response.
/// </summary>
/// <typeparam name="TResult">The type of the result.</typeparam>
[PublicAPI]
public sealed class GraphQlData<TResult>
{
    /// <summary>
    /// The result field of this response data.
    /// </summary>
    [JsonPropertyName("result")]
    public TResult? Result { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GraphQlData{TResult}"/> class.
    /// </summary>
    /// <param name="result">The result.</param>
    [JsonConstructor]
    public GraphQlData(TResult? result)
    {
        Result = result;
    }
}