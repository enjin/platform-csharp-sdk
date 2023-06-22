using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Extension methods for <see cref="IPlatformClient"/> representing Marketplace schema requests of the platform that
/// may be sent.
/// </summary>
/// <seealso cref="IPlatformClient"/>
[PublicAPI]
public static class MarketplaceSchema
{
    /// <summary>
    /// Creates a platform request for this schema.
    /// </summary>
    /// <param name="request">The <see cref="IGraphQlRequest"/> to form the request content.</param>
    /// <returns>The <see cref="IPlatformRequest"/> to send.</returns>
    private static IPlatformRequest CreateRequest(IGraphQlRequest request)
    {
        return PlatformRequest.Builder()
                              .SetPath("/graphql/marketplace")
                              .AddOperation(request.Compile(), request.VariablesWithoutTypes)
                              .Build();
    }

    #region Queries

    /// <summary>
    /// Sends a <see cref="GetBid"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetBid"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<MarketplaceBid>>> SendGetBid(
        this IPlatformClient client, GetBid request)
    {
        return client.SendRequest<GraphQlResponse<MarketplaceBid>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetBids"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetBids"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<MarketplaceBid>>>> SendGetBids(
        this IPlatformClient client, GetBids request)
    {
        return client.SendRequest<GraphQlResponse<Connection<MarketplaceBid>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetListing"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetListing"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<MarketplaceListing>>> SendGetListing(
        this IPlatformClient client, GetListing request)
    {
        return client.SendRequest<GraphQlResponse<MarketplaceListing>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetListings"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetListings"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<MarketplaceListing>>>> SendGetListings(
        this IPlatformClient client, GetListings request)
    {
        return client.SendRequest<GraphQlResponse<Connection<MarketplaceListing>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetSale"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetSale"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<MarketplaceSale>>> SendGetSale(
        this IPlatformClient client, GetSale request)
    {
        return client.SendRequest<GraphQlResponse<MarketplaceSale>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetSales"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetSales"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<MarketplaceSale>>>> SendGetSales(
        this IPlatformClient client, GetSales request)
    {
        return client.SendRequest<GraphQlResponse<Connection<MarketplaceSale>>>(CreateRequest(request));
    }

    #endregion Queries

    #region Mutations

    /// <summary>
    /// Sends a <see cref="CancelListing"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="CancelListing"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendCancelListing(
        this IPlatformClient client, CancelListing request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="CreateListing"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="CreateListing"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendCreateListing(
        this IPlatformClient client, CreateListing request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="FillListing"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="FillListing"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendFillListing(
        this IPlatformClient client, FillListing request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="FinalizeAuction"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="FinalizeAuction"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendFinalizeAuction(
        this IPlatformClient client, FinalizeAuction request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="PlaceBid"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="PlaceBid"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendPlaceBid(
        this IPlatformClient client, PlaceBid request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    #endregion Mutations
}