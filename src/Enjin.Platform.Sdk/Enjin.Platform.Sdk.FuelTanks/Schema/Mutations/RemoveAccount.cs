using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for removing an account from a fuel tank.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class RemoveAccount : GraphQlRequest<RemoveAccount, TransactionFragment>,
                             IHasIdempotencyKey<RemoveAccount>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveAccount"/> class.
    /// </summary>
    public RemoveAccount() : base("RemoveAccount", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveAccount SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the wallet account that will be removed from the fuel tank.
    /// </summary>
    /// <param name="userId">The account.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveAccount SetUserId(string? userId)
    {
        return SetVariable("userId", CoreTypes.String, userId);
    }
}