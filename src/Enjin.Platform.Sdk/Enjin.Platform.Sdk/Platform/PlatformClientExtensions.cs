using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Convenience extensions on <see cref="IPlatformClient"/> for dispatching GraphQL operations.
/// </summary>
[PublicAPI]
public static class PlatformClientExtensions
{
    /// <summary>
    /// Sends a GraphQL query built with <see cref="QueryQueryBuilder"/> and deserializes the
    /// <c>data</c> field as <see cref="Query"/>.
    /// </summary>
    /// <param name="client">The platform client.</param>
    /// <param name="builder">The query builder.</param>
    /// <returns>The platform response containing a <see cref="QueryResponse"/>.</returns>
    public static Task<IPlatformResponse<QueryResponse>> SendQuery(
        this IPlatformClient client,
        QueryQueryBuilder builder
    ) => client.SendRequest<QueryResponse>(PlatformRequest.GraphQl(builder));

    /// <summary>
    /// Sends a GraphQL mutation built with <see cref="MutationQueryBuilder"/> and deserializes the
    /// <c>data</c> field as <see cref="Mutation"/>.
    /// </summary>
    /// <param name="client">The platform client.</param>
    /// <param name="builder">The mutation builder.</param>
    /// <returns>The platform response containing a <see cref="MutationResponse"/>.</returns>
    public static Task<IPlatformResponse<MutationResponse>> SendMutation(
        this IPlatformClient client,
        MutationQueryBuilder builder
    ) => client.SendRequest<MutationResponse>(PlatformRequest.GraphQl(builder));
}
