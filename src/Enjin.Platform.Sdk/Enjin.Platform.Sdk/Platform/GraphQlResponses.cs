using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Concrete GraphQL response envelope for a <see cref="Query"/> operation.
/// Wraps the generated abstract <see cref="GraphQlResponse{TDataContract}"/>.
/// </summary>
[PublicAPI]
public sealed class QueryResponse : GraphQlResponse<Query>
{
}

/// <summary>
/// Concrete GraphQL response envelope for a <see cref="Mutation"/> operation.
/// Wraps the generated abstract <see cref="GraphQlResponse{TDataContract}"/>.
/// </summary>
[PublicAPI]
public sealed class MutationResponse : GraphQlResponse<Mutation>
{
}
