using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Extension methods for <see cref="IPlatformClient"/> representing Fuel Tanks schema requests of the platform that may
/// be sent.
/// </summary>
/// <seealso cref="IPlatformClient"/>
[PublicAPI]
public static class FuelTanksSchema
{
    /// <summary>
    /// Creates a platform request for this schema.
    /// </summary>
    /// <param name="request">The <see cref="IGraphQlRequest"/> to form the request content.</param>
    /// <returns>The <see cref="IPlatformRequest"/> to send.</returns>
    private static IPlatformRequest CreateRequest(IGraphQlRequest request)
    {
        return PlatformRequest.Builder()
                              .SetPath("/graphql/fuel-tanks")
                              .AddOperation(request.Compile(), request.VariablesWithoutTypes)
                              .Build();
    }

    #region Queries

    /// <summary>
    /// Sends a <see cref="GetAccounts"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetAccounts"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<Wallet>>>> SendGetAccounts(
        this IPlatformClient client, GetAccounts request)
    {
        return client.SendRequest<GraphQlResponse<Connection<Wallet>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetFuelTank"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetFuelTank"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<FuelTank>>> SendGetFuelTank(
        this IPlatformClient client, GetFuelTank request)
    {
        return client.SendRequest<GraphQlResponse<FuelTank>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetFuelTanks"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetFuelTanks"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<FuelTank>>>> SendGetFuelTanks(
        this IPlatformClient client, GetFuelTanks request)
    {
        return client.SendRequest<GraphQlResponse<Connection<FuelTank>>>(CreateRequest(request));
    }

    #endregion Queries

    #region Mutations

    /// <summary>
    /// Sends a <see cref="AddAccount"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="AddAccount"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendAddAccount(
        this IPlatformClient client, AddAccount request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="BatchAddAccount"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="BatchAddAccount"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendBatchAddAccount(
        this IPlatformClient client, BatchAddAccount request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="BatchRemoveAccount"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="BatchRemoveAccount"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendBatchRemoveAccount(
        this IPlatformClient client, BatchRemoveAccount request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="CreateFuelTank"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="CreateFuelTank"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendCreateFuelTank(
        this IPlatformClient client, CreateFuelTank request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="DestroyFuelTank"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="DestroyFuelTank"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendDestroyFuelTank(
        this IPlatformClient client, DestroyFuelTank request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="Dispatch"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="Dispatch"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendDispatch(
        this IPlatformClient client, Dispatch request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="DispatchAndTouch"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="DispatchAndTouch"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendDispatchAndTouch(
        this IPlatformClient client, DispatchAndTouch request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="InsertRuleSet"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="InsertRuleSet"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendInsertRuleSet(
        this IPlatformClient client, InsertRuleSet request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="MutateFuelTank"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="MutateFuelTank"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendMutateFuelTank(
        this IPlatformClient client, MutateFuelTank request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="RemoveAccount"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="RemoveAccount"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendRemoveAccount(
        this IPlatformClient client, RemoveAccount request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="RemoveAccountRuleData"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="RemoveAccountRuleData"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendRemoveAccountRuleData(
        this IPlatformClient client, RemoveAccountRuleData request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="RemoveRuleSet"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="RemoveRuleSet"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendRemoveRuleSet(
        this IPlatformClient client, RemoveRuleSet request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="ScheduleMutateFreezeState"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="ScheduleMutateFreezeState"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendScheduleMutateFreezeState(
        this IPlatformClient client, ScheduleMutateFreezeState request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="SetConsumption"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="SetConsumption"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendSetConsumption(
        this IPlatformClient client, SetConsumption request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    #endregion Mutations
}