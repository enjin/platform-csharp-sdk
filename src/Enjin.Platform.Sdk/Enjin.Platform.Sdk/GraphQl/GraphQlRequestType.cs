using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Enum values representing the types of GraphQL requests.
/// </summary>
[PublicAPI]
public enum GraphQlRequestType
{
    /// <summary>
    /// Value representing a query type of request.
    /// </summary>
    Query,

    /// <summary>
    /// Value representing a mutation type of request.
    /// </summary>
    Mutation,
}