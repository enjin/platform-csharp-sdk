using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for removing accounts from the fuel tank in a batch.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class BatchRemoveAccount : GraphQlRequest<BatchRemoveAccount, TransactionFragment>,
                                  IHasIdempotencyKey<BatchRemoveAccount>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BatchRemoveAccount"/> class.
    /// </summary>
    public BatchRemoveAccount() : base("BatchRemoveAccount", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public BatchRemoveAccount SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the wallet accounts that will be removed from the fuel tank.
    /// </summary>
    /// <param name="userIds">The accounts.</param>
    /// <returns>This request for chaining.</returns>
    public BatchRemoveAccount SetUserIds(params string[]? userIds)
    {
        return SetVariable("userIds", CoreTypes.StringArray, userIds);
    }
}