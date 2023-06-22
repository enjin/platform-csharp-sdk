using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Represents a GraphQL response message from the platform for a single operation.
/// </summary>
/// <typeparam name="TResult">The type to be returned in the result.</typeparam>
[PublicAPI]
public sealed class GraphQlResponse<TResult>
{
    /// <summary>
    /// The data of this response.
    /// </summary>
    [JsonPropertyName("data")]
    public GraphQlData<TResult>? Data { get; }

    /// <summary>
    /// The errors of this response if present.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<GraphQlError>? Errors { get; }

    /// <summary>
    /// Whether this response contains errors.
    /// </summary>
    public bool HasErrors => Errors != null && Errors.Any();

    /// <summary>
    /// Whether this response does not contain data.
    /// </summary>
    public bool IsEmpty => Data == null || Data.Result == null;

    /// <summary>
    /// Whether this response is successful. Must contain data and have no errors.
    /// </summary>
    public bool IsSuccess => !IsEmpty && !HasErrors;

    /// <summary>
    /// Initializes a new instance of the <see cref="GraphQlResponse{TResult}"/> class.
    /// </summary>
    /// <param name="data">The data for the response.</param>
    /// <param name="errors">The errors for the response.</param>
    [JsonConstructor]
    public GraphQlResponse(GraphQlData<TResult>? data, IEnumerable<GraphQlError>? errors)
    {
        Data = data;
        Errors = errors;
    }
}