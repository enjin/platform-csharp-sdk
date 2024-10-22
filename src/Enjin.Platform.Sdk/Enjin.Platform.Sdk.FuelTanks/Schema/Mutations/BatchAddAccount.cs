using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for adding new accounts to the fuel tank in a batch.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class BatchAddAccount : GraphQlRequest<BatchAddAccount, TransactionFragment>,
                               IHasIdempotencyKey<BatchAddAccount>,
                               IHasSkipValidation<BatchAddAccount>,
                               IHasSimulate<BatchAddAccount>,
                               IHasSigningAccount<BatchAddAccount>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BatchAddAccount"/> class.
    /// </summary>
    public BatchAddAccount() : base("BatchAddAccount", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public BatchAddAccount SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the wallet accounts that will be added to the fuel tank.
    /// </summary>
    /// <param name="userIds">The accounts.</param>
    /// <returns>This request for chaining.</returns>
    public BatchAddAccount SetUserIds(params string[]? userIds)
    {
        return SetVariable("userIds", CoreTypes.StringArray, userIds);
    }
}