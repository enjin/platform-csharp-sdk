using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Extension methods for <see cref="IPlatformClient"/> representing core schema requests of the platform that may be
/// sent.
/// </summary>
/// <seealso cref="IPlatformClient"/>
[PublicAPI]
public static class CoreSchema
{
    /// <summary>
    /// Creates a platform request for this schema.
    /// </summary>
    /// <param name="request">The <see cref="IGraphQlRequest"/> to form the request content.</param>
    /// <returns>The <see cref="IPlatformRequest"/> to send.</returns>
    private static IPlatformRequest CreateRequest(IGraphQlRequest request)
    {
        return PlatformRequest.Builder()
                              .SetPath("/graphql")
                              .AddOperation(request.Compile(), request.VariablesWithoutTypes)
                              .Build();
    }

    #region Queries

    /// <summary>
    /// Sends a <see cref="GetBlocks"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetBlocks"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<Block>>>> SendGetBlocks(
        this IPlatformClient client, GetBlocks request)
    {
        return client.SendRequest<GraphQlResponse<Connection<Block>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetCollection"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetCollection"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Collection>>> SendGetCollection(
        this IPlatformClient client, GetCollection request)
    {
        return client.SendRequest<GraphQlResponse<Collection>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetCollections"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetCollections"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<Collection>>>> SendGetCollections(
        this IPlatformClient client, GetCollections request)
    {
        return client.SendRequest<GraphQlResponse<Connection<Collection>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetToken"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetToken"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Token>>> SendGetToken(
        this IPlatformClient client, GetToken request)
    {
        return client.SendRequest<GraphQlResponse<Token>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetTokens"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetTokens"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<Token>>>> SendGetTokens(
        this IPlatformClient client, GetTokens request)
    {
        return client.SendRequest<GraphQlResponse<Connection<Token>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetTransaction"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetTransaction"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendGetTransaction(
        this IPlatformClient client, GetTransaction request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetTransactions"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetTransactions"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<Transaction>>>> SendGetTransactions(
        this IPlatformClient client, GetTransactions request)
    {
        return client.SendRequest<GraphQlResponse<Connection<Transaction>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetWallet"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetWallet"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Wallet>>> SendGetWallet(
        this IPlatformClient client, GetWallet request)
    {
        return client.SendRequest<GraphQlResponse<Wallet>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="VerifyMessage"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="VerifyMessage"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendVerifyMessage(
        this IPlatformClient client, VerifyMessage request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetAccountVerified"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetAccountVerified"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<AccountVerified>>> SendGetAccountVerified(
        this IPlatformClient client, GetAccountVerified request)
    {
        return client.SendRequest<GraphQlResponse<AccountVerified>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetLinkingCode"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetLinkingCode"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<WalletLink>>> SendGetLinkingCode(
        this IPlatformClient client, GetLinkingCode request)
    {
        return client.SendRequest<GraphQlResponse<WalletLink>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetPendingEvents"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetPendingEvents"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<PendingEvent>>>> SendGetPendingEvents(
        this IPlatformClient client, GetPendingEvents request)
    {
        return client.SendRequest<GraphQlResponse<Connection<PendingEvent>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="GetPendingWallets"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="GetPendingWallets"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<Wallet>>>> SendGetPendingWallets(
        this IPlatformClient client, GetPendingWallets request)
    {
        return client.SendRequest<GraphQlResponse<Connection<Wallet>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="RequestAccount"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="RequestAccount"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<AccountRequest>>> SendRequestAccount(
        this IPlatformClient client, RequestAccount request)
    {
        return client.SendRequest<GraphQlResponse<AccountRequest>>(CreateRequest(request));
    }

    #endregion Queries

    #region Mutations

    /// <summary>
    /// Sends a <see cref="ApproveCollection"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="ApproveCollection"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendApproveCollection(
        this IPlatformClient client, ApproveCollection request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="ApproveToken"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="ApproveToken"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendApproveToken(
        this IPlatformClient client, ApproveToken request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="BatchMint"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="BatchMint"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendBatchMint(
        this IPlatformClient client, BatchMint request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="BatchSetAttribute"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="BatchSetAttribute"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendBatchSetAttribute(
        this IPlatformClient client, BatchSetAttribute request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="BatchTransfer"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="BatchTransfer"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendBatchTransfer(
        this IPlatformClient client, BatchTransfer request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="Burn"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="Burn"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendBurn(
        this IPlatformClient client, Burn request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="CreateCollection"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="CreateCollection"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendCreateCollection(
        this IPlatformClient client, CreateCollection request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="CreateToken"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="CreateToken"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendCreateToken(
        this IPlatformClient client, CreateToken request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="DestroyCollection"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="DestroyCollection"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendDestroyCollection(
        this IPlatformClient client, DestroyCollection request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="Freeze"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="Freeze"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendFreeze(
        this IPlatformClient client, Freeze request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="MintToken"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="MintToken"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendMintToken(
        this IPlatformClient client, MintToken request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="MutateCollection"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="MutateCollection"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendMutateCollection(
        this IPlatformClient client, MutateCollection request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="MutateToken"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="MutateToken"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendMutateToken(
        this IPlatformClient client, MutateToken request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="OperatorTransferToken"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="OperatorTransferToken"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendOperatorTransferToken(
        this IPlatformClient client, OperatorTransferToken request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="RemoveAllAttributes"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="RemoveAllAttributes"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendRemoveAllAttributes(
        this IPlatformClient client, RemoveAllAttributes request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="RemoveCollectionAttribute"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="RemoveCollectionAttribute"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendRemoveCollectionAttribute(
        this IPlatformClient client, RemoveCollectionAttribute request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="RemoveTokenAttribute"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="RemoveTokenAttribute"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendRemoveTokenAttribute(
        this IPlatformClient client, RemoveTokenAttribute request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="SendTransaction"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="SendTransaction"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<string>>> SendSendTransaction(
        this IPlatformClient client, SendTransaction request)
    {
        return client.SendRequest<GraphQlResponse<string>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="SetCollectionAttribute"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="SetCollectionAttribute"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendSetCollectionAttribute(
        this IPlatformClient client, SetCollectionAttribute request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="SetTokenAttribute"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="SetTokenAttribute"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendSetTokenAttribute(
        this IPlatformClient client, SetTokenAttribute request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="SimpleTransferToken"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="SimpleTransferToken"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendSimpleTransferToken(
        this IPlatformClient client, SimpleTransferToken request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="Thaw"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="Thaw"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendThaw(
        this IPlatformClient client, Thaw request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="TransferAllBalance"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="TransferAllBalance"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendTransferAllBalance(
        this IPlatformClient client, TransferAllBalance request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="TransferBalance"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="TransferBalance"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendTransferBalance(
        this IPlatformClient client, TransferBalance request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="UnapproveCollection"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="UnapproveCollection"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendUnapproveCollection(
        this IPlatformClient client, UnapproveCollection request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="UnapproveToken"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="UnapproveToken"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Transaction>>> SendUnapproveToken(
        this IPlatformClient client, UnapproveToken request)
    {
        return client.SendRequest<GraphQlResponse<Transaction>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="AcknowledgeEvents"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="AcknowledgeEvents"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendAcknowledgeEvents(
        this IPlatformClient client, AcknowledgeEvents request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="CreateWallet"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="CreateWallet"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendCreateWallet(
        this IPlatformClient client, CreateWallet request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="MarkAndListPendingTransactions"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="MarkAndListPendingTransactions"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<Connection<Transaction>>>> SendMarkAndListPendingTransactions(
        this IPlatformClient client, MarkAndListPendingTransactions request)
    {
        return client.SendRequest<GraphQlResponse<Connection<Transaction>>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="SetWalletAccount"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="SetWalletAccount"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendSetWalletAccount(
        this IPlatformClient client, SetWalletAccount request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="UpdateTransaction"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="UpdateTransaction"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendUpdateTransaction(
        this IPlatformClient client, UpdateTransaction request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="UpdateWalletExternalId"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="UpdateWalletExternalId"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendUpdateWalletExternalId(
        this IPlatformClient client, UpdateWalletExternalId request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    /// <summary>
    /// Sends a <see cref="VerifyAccount"/> request to the platform.
    /// </summary>
    /// <param name="client">The <see cref="IPlatformClient"/> to send the request from.</param>
    /// <param name="request">The <see cref="VerifyAccount"/> request to send.</param>
    /// <returns>The task containing the response.</returns>
    public static Task<IPlatformResponse<GraphQlResponse<bool?>>> SendVerifyAccount(
        this IPlatformClient client, VerifyAccount request)
    {
        return client.SendRequest<GraphQlResponse<bool?>>(CreateRequest(request));
    }

    #endregion Mutations
}