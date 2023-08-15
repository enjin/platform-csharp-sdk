using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Extension methods for <see cref="IPlatformClient"/> representing Beam schema requests of the platform that may be
/// sent.
/// </summary>
/// <seealso cref="IPlatformClient"/>
[PublicAPI]
public static class BeamSchema
{
    /// <summary>
    /// Creates a platform request for this schema.
    /// </summary>
    /// <param name="request">The <see cref="IGraphQlRequest"/> to form the request content.</param>
    /// <returns>The <see cref="IPlatformRequest"/> to send.</returns>
    private static IPlatformRequest CreateRequest(IGraphQlRequest request)
    {
        return PlatformRequest.Builder()
                              .SetPath("/graphql/beam")
                              .AddOperation(request.Compile(), request.VariablesWithoutTypes)
                              .Build();
    }

    #region Queries

    /// <summary>
    /// Sends a <see cref="GetBeam"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetBeam"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Beam>>> SendGetBeam(
        this IPlatformClient client, GetBeam request)
    {
        return client.SendRequest<GraphQlResponse<Beam>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetBeams"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetBeams"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<Beam>>>> SendGetBeams(
        this IPlatformClient client, GetBeams request)
    {
        return client.SendRequest<GraphQlResponse<Connection<Beam>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetClaims"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetClaims"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<BeamClaim>>>> SendGetClaims(
        this IPlatformClient client, GetClaims request)
    {
        return client.SendRequest<GraphQlResponse<Connection<BeamClaim>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetSingleUseCodes"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetSingleUseCodes"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<BeamClaim>>>> SendGetSingleUseCodes(
        this IPlatformClient client, GetSingleUseCodes request)
    {
        return client.SendRequest<GraphQlResponse<Connection<BeamClaim>>>(CreateRequest(request));
    }

    #endregion Queries

    #region Mutations

    /// <summary>
    /// Sends a <see cref="ClaimBeam"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="ClaimBeam"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendClaimBeam(
        this IPlatformClient client, ClaimBeam request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="CreateBeam"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="CreateBeam"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<string?>>> SendCreateBeam(
        this IPlatformClient client, CreateBeam request)
    {
        return client.SendRequest<GraphQlResponse<string?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="DeleteBeam"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="DeleteBeam"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendDeleteBeam(
        this IPlatformClient client, DeleteBeam request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="ExpireSingleUseCodes"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="ExpireSingleUseCodes"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendExpireSingleUseCodes(
        this IPlatformClient client, ExpireSingleUseCodes request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="RemoveTokens"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="RemoveTokens"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendRemoveTokens(
        this IPlatformClient client, RemoveTokens request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="UpdateBeam"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="UpdateBeam"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendUpdateBeam(
        this IPlatformClient client, UpdateBeam request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    #endregion Mutations
}