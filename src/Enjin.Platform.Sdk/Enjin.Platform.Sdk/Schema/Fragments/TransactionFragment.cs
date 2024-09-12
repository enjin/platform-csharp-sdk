using System.Text.Json;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="Transaction"/> returned by the platform.
/// </summary>
[PublicAPI]
public class TransactionFragment : GraphQlFragment<TransactionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionFragment"/> class.
    /// </summary>
    public TransactionFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Transaction"/> is to be returned with its <see cref="Transaction.Id"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Transaction"/> is to be returned with its <see cref="Transaction.TransactionId"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithTransactionId(bool isIncluded = true)
    {
        return WithField("transactionId", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="Transaction"/> is to be returned with its <see cref="Transaction.TransactionHash"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithTransactionHash(bool isIncluded = true)
    {
        return WithField("transactionHash", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Transaction"/> is to be returned with its <see cref="Transaction.Method"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithMethod(bool isIncluded = true)
    {
        return WithField("method", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Transaction"/> is to be returned with its <see cref="Transaction.State"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithState(bool isIncluded = true)
    {
        return WithField("state", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Transaction"/> is to be returned with its <see cref="Transaction.Result"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithResult(bool isIncluded = true)
    {
        return WithField("result", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Transaction"/> is to be returned with its <see cref="Transaction.EncodedData"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithEncodedData(bool isIncluded = true)
    {
        return WithField("encodedData", isIncluded);
    }
    
    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Transaction.SigningPayload"/> property of
    /// the <see cref="Transaction"/>.
    /// </summary>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithSigningPayload(bool isIncluded = true)
    {
        return WithField("signingPayload", isIncluded);
    }
    
    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Transaction.SigningPayloadJson"/> property of
    /// the <see cref="Transaction"/>.
    /// </summary>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithSigningPayloadJson(bool isIncluded = true)
    {
        return WithField("signingPayloadJson", isIncluded);
    }
    
    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Transaction.Fee"/> property of
    /// the <see cref="Transaction"/>.
    /// </summary>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithFee(bool isIncluded = true)
    {
        return WithField("fee", isIncluded);
    }
    
    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Transaction.Deposit"/> property of
    /// the <see cref="Transaction"/>.
    /// </summary>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithDeposit(bool isIncluded = true)
    {
        return WithField("deposit", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Transaction.Wallet"/> property of
    /// the <see cref="Transaction"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithWallet(WalletFragment? fragment = null)
    {
        return WithField("wallet", fragment);
    }
    
    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Transaction.Network"/> property of
    /// the <see cref="Transaction"/>.
    /// </summary>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithNetwork(bool isIncluded = true)
    {
        return WithField("network", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Transaction"/> is to be returned with its <see cref="Transaction.IdempotencyKey"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithIdempotencyKey(bool isIncluded = true)
    {
        return WithField("idempotencyKey", isIncluded);
    }
    
    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Transaction.SignedAtBlock"/> property of
    /// the <see cref="Transaction"/>.
    /// </summary>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithSSignedAtBlock(bool isIncluded = true)
    {
        return WithField("signedAtBlock", isIncluded);
    }
    
    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Transaction.CreatedAt"/> property of
    /// the <see cref="Transaction"/>.
    /// </summary>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithCreatedAt(bool isIncluded = true)
    {
        return WithField("createAt", isIncluded);
    }
    
    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="Transaction.UpdatedAt"/> property of
    /// the <see cref="Transaction"/>.
    /// </summary>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithUpdatedAt(bool isIncluded = true)
    {
        return WithField("updatedAt", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="Event"/>, to be used for getting the
    /// <see cref="Transaction.Events"/> property of the <see cref="Transaction"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="Event"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public TransactionFragment WithEvents(EventConnectionFragment? fragment = null)
    {
        return WithField("events", fragment);
    }
}